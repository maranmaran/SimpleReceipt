using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLayer.Data;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.DTOs;
using ServiceLayer.Operations;

namespace ServiceLayer.Tests.Operations
{
    [TestClass]
    public class ReceiptOperationsTests
    {
        private ApplicationDbContext _context;
        private IReceiptOperations _receiptOperations;

        public ReceiptOperationsTests()
        {
            ServiceAutomapper.Configure();
        }

        [TestInitialize]
        public void Init()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            _receiptOperations = new ReceiptOperations(_context);

            InMemoryDb.InitMe(ref _context);
        }

        [TestMethod]
        public void CreateReceipt_Successful()
        {

            var receipt = this.CreateAndGetReceipt();

            Assert.IsTrue(receipt != null);
            Assert.IsTrue(receipt.Id == 1);

        }

        [TestMethod]
        public void GetAllReceiptPriceTableQueryByReceiptId_Successful()
        {
            var receipt = this.CreateAndGetReceipt();
            var priceTableQueries = _receiptOperations.GetAllReceiptPriceTableQueryByReceiptId(receipt.Id).Result;

            Assert.IsTrue(priceTableQueries != null);
            Assert.AreEqual(priceTableQueries.Count, 2);
        }

        [TestMethod]
        public void GetAllReceiptsByCafeId_Successful()
        {
            var createdReceipt = this.CreateAndGetReceipt();
            var cafe = _context.Cafes.First();
            var receipts = _receiptOperations.GetAllReceiptsByCafeId(cafe.Id).Result;

            Assert.IsTrue(receipts != null && receipts.Count > 0);
        }

        private Receipt CreateAndGetReceipt()
        {
            var waiter = _context.ApplicationUsers.First();
            var table = _context.Tables.First();
            var cafe = _context.Cafes.First();
            var priceTableQueries = cafe.PriceTable.PriceTableQueries.ToList();

            var receipt = new ReceiptDto()
            {
                Cafe = cafe,
                Table = table,
                Waiter = waiter,
                ReceiptPriceTableQueries = new List<ReceiptPriceTableQuery>()
                {
                    new ReceiptPriceTableQuery()
                    {
                        PriceTableQuery = priceTableQueries.First(),
                        Quantity = 2
                    },
                    new ReceiptPriceTableQuery()
                    {
                        PriceTableQuery = priceTableQueries.Last(),
                        Quantity = 1
                    },
                    new ReceiptPriceTableQuery()
                    {
                        PriceTableQuery = priceTableQueries.First(),
                        Quantity = 4
                    },
                }
            };

            _receiptOperations.CreateReceipt(receipt);

            return _context.Receipts.Last();
        }
    }
}
