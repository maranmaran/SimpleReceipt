using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Operations;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ReceiptsController : Controller
    {
        private readonly IReceiptOperations _receiptOperations;

        public ReceiptsController(IReceiptOperations receiptOperations)
        {
            _receiptOperations = receiptOperations;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllReceipts(long id)
        {
            var result = await _receiptOperations.GetAllReceiptsByCafeId(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateReceipt([FromBody] ReceiptDto receipt)
        {
            _receiptOperations.CreateReceipt(receipt);
            return NoContent();
        }

    }

}
