﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Operations;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CafeController : Controller
    {
        private readonly IApplicationUserOperations _applicationUserOperations;
        private readonly ITableOperations _tableOperations;
        private readonly ICafeOperations _cafeOperations;
        private readonly IPriceTableQueryOperations _priceTableQueryOperations;


        public CafeController(
            IApplicationUserOperations applicationUserOperations, ITableOperations tableOperations, ICafeOperations cafeOperations, IPriceTableQueryOperations priceTableQueryOperations)
        {
            _applicationUserOperations = applicationUserOperations;
            _tableOperations = tableOperations;
            _cafeOperations = cafeOperations;
            _priceTableQueryOperations = priceTableQueryOperations;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCafes(string id)
        {
            var result = await _cafeOperations.GetAllByUserId(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllWaiters(long id)
        {
            var result = await _applicationUserOperations.GetAllWaitersByCafeId(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTables(long id)
        {
            var result = await _tableOperations.GetAllByCafeId(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllPriceTableQueries(long id)
        {
            var result = await _priceTableQueryOperations.GetAllPriceTableQueriesByCafeId(id);
            return Ok(result);
        }
    }
}
