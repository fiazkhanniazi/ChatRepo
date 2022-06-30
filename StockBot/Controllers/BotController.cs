using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockBot.Stock;
using Contracts;

namespace StockBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BotController : ControllerBase
    {
        private readonly IStockManager _stockManager;
       // private readonly IBus _bus;
        public BotController(IStockManager stockManager)
        {
            _stockManager = stockManager;
           // _bus = bus;
        }


        [HttpPost]
        public async Task<string> StockCode(SendRecieveMessageViewModel model)
        {

          return await _stockManager.StockCode(model);



            //return Ok();
        }
    }
}
