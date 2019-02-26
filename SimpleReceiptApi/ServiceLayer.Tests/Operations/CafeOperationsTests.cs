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

        public CafeOperationsTests()
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
            _cafeOperations = new CafeOperations(_context);

            InMemoryDb.InitMe(ref _context);
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
