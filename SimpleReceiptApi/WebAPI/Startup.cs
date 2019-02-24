using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //// ===== Add Identity ========
            //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //{
            //    options.Password.RequiredLength = 3;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireDigit = false;
            //})
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

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
            //services.AddInternalServices();

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
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
            // db.Database.Migrate();
            //CreateRoles(serviceProvider).Wait();

            // ===== Automapper ======
            //ServiceAutomapper.Configure();
            //AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            ////initializing custom roles 
            //var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            //string[] roleNames = { "Admin", "Coach", "Athlete" };

            //foreach (var roleName in roleNames)
            //{
            //    var roleExist = await roleManager.RoleExistsAsync(roleName);
            //    if (!roleExist)
            //    {
            //        //create the roles and seed them to the database: Question 1
            //        await roleManager.CreateAsync(new IdentityRole(roleName));
            //    }
            //}

            //var userAdmin = await userManager.FindByEmailAsync(Configuration["AppSettings:UserEmailAdmin"]);
            //var userCoach = await userManager.FindByEmailAsync(Configuration["AppSettings:UserEmailCoach"]);
            //var userAthlete = await userManager.FindByEmailAsync(Configuration["AppSettings:UserEmailAthlete"]);

            //if (userAdmin == null && userCoach == null && userAthlete == null)
            //{

            //    //Here you could create a super user who will maintain the web app
            //    var adminUser = new ApplicationUser
            //    {
            //        UserName = Configuration["AppSettings:UserNameAdmin"],
            //        Email = Configuration["AppSettings:UserEmailAdmin"],
            //        FirstName = "Marko",
            //        LastName = "Urh",
            //        Gender = Gender.Male.ToString(),
            //    };
            //    //Ensure you have these values in your appsettings.json file
            //    var adminUserPass = Configuration["AppSettings:UserPasswordAdmin"];
            //    var createAdminUser = await userManager.CreateAsync(adminUser, adminUserPass);


            //    var coachUser = new ApplicationUser
            //    {
            //        UserName = Configuration["AppSettings:UserNameCoach"],
            //        Email = Configuration["AppSettings:UserEmailCoach"],
            //        FirstName = "Filip",
            //        LastName = "Matijević",
            //        Gender = Gender.Male.ToString(),
            //    };
            //    //Ensure you have these values in your appsettings.json file
            //    var coachUserPass = Configuration["AppSettings:UserPasswordCoach"];
            //    var createCoachUser = await userManager.CreateAsync(coachUser, coachUserPass);

            //    var userId = userManager.FindByNameAsync(Configuration["AppSettings:UserNameCoach"]).Result.Id;
            //    var athleteUser = new ApplicationUser
            //    {
            //        UserName = Configuration["AppSettings:UserNameAthlete"],
            //        Email = Configuration["AppSettings:UserEmailAthlete"],
            //        FirstName = "Andrej",
            //        LastName = "Švenda",
            //        CoachId = userId,
            //        Gender = Gender.Male.ToString(),
            //    };
            //    //Ensure you have these values in your appsettings.json file
            //    var athleteUserPass = Configuration["AppSettings:UserPasswordAthlete"];
            //    var createAthleteUser = await userManager.CreateAsync(athleteUser, athleteUserPass);

            //    if (createAdminUser.Succeeded && createCoachUser.Succeeded && createAthleteUser.Succeeded)
            //    {
            //        await userManager.AddToRoleAsync(adminUser, "Admin");
            //        await userManager.AddToRoleAsync(adminUser, "Coach");
            //        await userManager.AddToRoleAsync(adminUser, "Athlete");

            //        await userManager.AddToRoleAsync(coachUser, "Coach");

            //        await userManager.AddToRoleAsync(athleteUser, "Athlete");

            //        athleteUser.AthleteId = athleteUser.Id;
            //        athleteUser.ExerciseTypes =
            //            new PrePopulateData()
            //            .ExerciseUponAccountCreation
            //                .AddTo(new Collection<ExerciseType>());

            //        await userManager.UpdateAsync(athleteUser);

            //        coachUser.AthleteId = coachUser.Id;
            //        coachUser.ExerciseTypes =
            //            new PrePopulateData()
            //                .ExerciseUponAccountCreation
            //                .AddTo(new Collection<ExerciseType>());
            //        await userManager.UpdateAsync(coachUser);
            //    }
            }
        }
}
