using System;
using System.Threading;
using System.Threading.Tasks;

using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/Accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
      

        public AccountsController(IServiceManager serviceManager) => _serviceManager = serviceManager;
        [Route("registerUser")]
        [HttpPost]
        public async Task<string> RegisterUser([FromBody] RegisterViewModel model, CancellationToken cancellationToken)
        {
            try
            {
                var accountsDto = await _serviceManager.AccountService.RegisterAsync(model, cancellationToken);

               return  "true";
            }
            catch(Exception ex)
            {

                return ex.Message;
            }
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model, CancellationToken cancellationToken)
        {
           
            var response = await _serviceManager.AccountService.LoginAsync(model, cancellationToken);
            
            return Ok(response) ;
        }

      
    }
}