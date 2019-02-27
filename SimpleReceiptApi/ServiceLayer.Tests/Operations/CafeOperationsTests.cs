using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseLayer.Data;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.Operations;

namespace ServiceLayer.Tests.Operations
{
    [TestClass]
    public class CafeOperationsTests
    {
        private ApplicationDbContext _context;
        private ICafeOperations _cafeOperations;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            ServiceAutomapper.Configure();
        }

        [TestInitialize]
        public void Initialize()
        {
            _context = InMemoryDb.GetContext();
            _cafeOperations = new CafeOperations(_context);
        }

        [TestMethod]
        public void GetsAllByUserId_Successful()
        {
            var user = _context.ApplicationUsers.First();
            var cafes = _cafeOperations.GetAllByUserId(user.Id).Result;

            Assert.IsTrue(cafes.Any());
        }
    }
}
