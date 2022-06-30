using System;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class ChatController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
       
        public ChatController(IServiceManager serviceManager) {

            _serviceManager = serviceManager;
            
        }


      


        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendRecieveMessageViewModel sendMessageInputDTO)
        {
            try
            {
                await _serviceManager.ChatService.SendMessageAsync(sendMessageInputDTO);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        

        //[HttpGet]
        //public async Task<IActionResult> RecieveMessage([FromBody] SendRecieveMessageDTO sendMessageInputDTO)
        //{
        //    try
        //    {
        //        await _serviceManager.ChatService.RecieveMessageAsync(sendMessageInputDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok();
        //}


    }
}
