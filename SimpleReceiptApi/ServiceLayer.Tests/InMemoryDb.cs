using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLayer.Data;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Tests
{
    public static class InMemoryDb
    {
        public static ApplicationDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            var waiter1 = new ApplicationUser()
            {
                Email = "waiter1@gmail.com",
                UserName = "waiter1",
                FirstName = "waiter",
                LastName = "1"
            };

            var waiter2 = new ApplicationUser()
            {
                Email = "waiter1@gmail.com",
                UserName = "waiter1",
                FirstName = "waiter",
                LastName = "1"
            };

            var waiter3 = new ApplicationUser()
            {
                Email = "waiter1@gmail.com",
                UserName = "waiter1",
                FirstName = "waiter",
                LastName = "1"
            };



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
                };


            if (!context.Companies.Any())
            {
                context.Companies.Add(company);
                context.WaiterCafes.AddRange(waiterCafes);
                context.PriceTables.AddRange(new List<PriceTable>() { priceTable1, priceTable2 });
                context.SaveChanges();
            }

            return context;
        }
    }
}
