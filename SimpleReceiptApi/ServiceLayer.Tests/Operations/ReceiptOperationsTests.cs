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

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ServiceAutomapper.Configure();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _context = InMemoryDb.GetContext();
            _receiptOperations = new ReceiptOperations(_context);
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
            Assert.AreEqual(3, priceTableQueries.Count);
        }

        [TestMethod]
        public void GetAllReceiptPriceTableQueryByReceiptId_Merges()
        {
            var receipt = this.CreateAndGetReceipt(merge: true);
            var priceTableQueries = _receiptOperations.GetAllReceiptPriceTableQueryByReceiptId(receipt.Id).Result;

            Assert.IsTrue(priceTableQueries != null);
            Assert.AreEqual(2, priceTableQueries.Count);
        }

        [TestMethod]
        public void GetAllReceiptsByCafeId_Successful()
        {
            this.CreateAndGetReceipt();
            var cafe = _context.Cafes.First();
            var receipts = _receiptOperations.GetAllReceiptsByCafeId(cafe.Id).Result;

            Assert.IsTrue(receipts != null && receipts.Count > 0);
        }

        private Receipt CreateAndGetReceipt(bool merge = false)
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
                        PriceTableQueryId = priceTableQueries[0].Id,
                        Quantity = 2
                    },
                    new ReceiptPriceTableQuery()
                    {
                        PriceTableQueryId = priceTableQueries[1].Id,
                        Quantity = 1
                    },
                    new ReceiptPriceTableQuery()
                    {
                        PriceTableQueryId = merge ? priceTableQueries[0].Id : priceTableQueries[2].Id,
                        Quantity = 4
                    },
                }
            };

            _receiptOperations.CreateReceipt(receipt);

            return _context.Receipts.Last();
        }
    }
}
