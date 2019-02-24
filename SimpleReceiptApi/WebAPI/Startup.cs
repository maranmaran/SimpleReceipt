using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer.Data;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ServiceLayer;
using ServiceLayer.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using WebAPI.Middleware;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ===== Add DbContext ========
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // ===== Add Identity ========
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });

            // ===== Add internal services (operations) ========
            services.AddInternalServices();

            // ===== Add CORS ========
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    p => p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });

            // ===== Add MVC ========
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Discipline of strength API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ApplicationDbContext db)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseCors("AllowAll");
                app.UseMiddleware<MaintainCorsHeadersMiddleware>();

                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple receipt api");
                c.RoutePrefix = "api";
            });

            // ===== Error handling middleware =====
            app.ConfigureExceptionHandler();

            // ===== Use Authentication ======
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            // ===== For angular app in wwwwroot ====
            app.UseDefaultFiles();
            app.UseStaticFiles(); // For the wwwroot folder

            // ===== Create tables ======
            db.Database.Migrate();
            CreateRoles(serviceProvider, db).Wait();

            // ===== Automapper ======
            ServiceAutomapper.Configure();
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            //initializing custom roles 
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Waiter" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Here you could create a super user who will maintain the web app
            var adminUser = new ApplicationUser
            {
                UserName = Configuration["AppSettings:UserNameAdmin"],
                Email = Configuration["AppSettings:UserEmailAdmin"],
                FirstName = "Marko",
                LastName = "Urh",
            };
            var waiter1 = new ApplicationUser
            {
                UserName = Configuration["AppSettings:UserNameW1"],
                Email = Configuration["AppSettings:UserEmailW1"],
                FirstName = "Waiter",
                LastName = "1",
            };
            var waiter2 = new ApplicationUser
            {
                UserName = Configuration["AppSettings:UserNameW2"],
                Email = Configuration["AppSettings:UserEmailW2"],
                FirstName = "Waiter",
                LastName = "2",
            };
            var waiter3 = new ApplicationUser
            {
                UserName = Configuration["AppSettings:UserNameW3"],
                Email = Configuration["AppSettings:UserEmailW3"],
                FirstName = "Waiter",
                LastName = "3",
            };

            //Ensure you have these values in your appsettings.json file
            var adminUserPass = Configuration["AppSettings:UserPasswordAdmin"];
            var w1UserPass = Configuration["AppSettings:UserPasswordW1"];
            var w2UserPass = Configuration["AppSettings:UserPasswordW2"];
            var w3UserPass = Configuration["AppSettings:UserPasswordW3"];

            var createAdminUser = await userManager.CreateAsync(adminUser, adminUserPass);
            var createW1 = await userManager.CreateAsync(waiter1, w1UserPass);
            var createW2 = await userManager.CreateAsync(waiter2, w2UserPass);
            var createW3 = await userManager.CreateAsync(waiter3, w3UserPass);

            if (createAdminUser.Succeeded && createW1.Succeeded && createW2.Succeeded && createW3.Succeeded)
            {
                userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                userManager.AddToRoleAsync(adminUser, "Waiter").Wait();

                userManager.AddToRoleAsync(waiter1, "Waiter").Wait();
                userManager.AddToRoleAsync(waiter2, "Waiter").Wait();
                userManager.AddToRoleAsync(waiter3, "Waiter").Wait();


                var product1 = new Product()
                {
                    Name = "Beverage1",
                    Type = '0',
                };
                var product2 = new Product()
                {
                    Name = "Beverage2",
                    Type = '0',
                };
                var product3 = new Product()
                {
                    Name = "Beverage3",
                    Type = '0',
                };

                var cafe1 = new Cafe()
                {
                    Name = "Cafe1",
                    Tables = new List<Table>()
                    {
                        new Table()
                        {
                            Name = "Table1"
                        },
                        new Table()
                        {
                            Name = "Table2"
                        },
                        new Table()
                        {
                            Name = "Table3"
                        },
                    },
                };

                var cafe2 = new Cafe()
                {
                    Name = "Cafe2",
                    Tables = new List<Table>()
                    {
                        new Table()
                        {
                            Name = "Table1"
                        },
                        new Table()
                        {
                            Name = "Table2"
                        },
                        new Table()
                        {
                            Name = "Table3"
                        },
                    },
                };

                var priceTable1 = new PriceTable()
                {
                    Cafe = cafe1,
                    PriceTableQueries = new List<PriceTableQuery>()
                    {
                        new PriceTableQuery()
                        {
                            Price = 2,
                            Product = product1
                        },
                        new PriceTableQuery()
                        {
                            Price = 1,
                            Product = product2
                        },
                        new PriceTableQuery()
                        {
                            Price = 3,
                            Product = product3
                        },
                    }
                };

                var priceTable2 = new PriceTable()
                {
                    Cafe = cafe2,
                    PriceTableQueries = new List<PriceTableQuery>()
                    {
                        new PriceTableQuery()
                        {
                            Price = 2,
                            Product = product1
                        },
                        new PriceTableQuery()
                        {
                            Price = 1,
                            Product = product2
                        },
                        new PriceTableQuery()
                        {
                            Price = 3,
                            Product = product3
                        },
                    }
                };

                var company = new Company()
                {
                    Name = "Company",
                    Products = new List<Product>()
                    {
                        product1,
                        product2,
                        product3
                    },
                    Cafes = new List<Cafe>()
                    {
                        cafe1,
                        cafe2
                    }
                };

                var waiterCafes = new List<WaiterCafe>()
                {
                    new WaiterCafe()
                    {
                        Cafe = cafe1,
                        Waiter = waiter1
                    },
                    new WaiterCafe()
                    {
                        Cafe = cafe1,
                        Waiter = waiter2
                    },
                    new WaiterCafe()
                    {
                        Cafe = cafe1,
                        Waiter = waiter3
                    },
                    new WaiterCafe()
                    {
                        Cafe = cafe2,
                        Waiter = waiter1
                    },
                    new WaiterCafe()
                    {
                        Cafe = cafe2,
                        Waiter = waiter2
                    },
                    new WaiterCafe()
                    {
                        Cafe = cafe2,
                        Waiter = waiter3
                    },
                    new WaiterCafe()
                    {
                        Cafe = cafe1,
                        Waiter = adminUser
                    },
                    new WaiterCafe()
                    {
                        Cafe = cafe2,
                        Waiter = adminUser
                    }
                };


                if (!context.Companies.Any())
                {
                    context.Companies.Add(company);
                    context.WaiterCafes.AddRange(waiterCafes);
                    context.PriceTables.AddRange(new List<PriceTable>() { priceTable1, priceTable2 });
                    context.SaveChanges();
                }
            }
        }
    }
}
