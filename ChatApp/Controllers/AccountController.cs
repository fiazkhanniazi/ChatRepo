using ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Session;

namespace ChatApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly HttpClient _client;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            string result ="";
            try
            {
                model.RememberMe = true;
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:44319/api/accounts/login";


                var response = await _client.PostAsync(url, data);

                 result = response.Content.ReadAsStringAsync().Result;
                if(result == "true")
                {
                    HttpContext.Session.SetString("UserName", model.Email);
                    TempData["userName"] = model.Email;
                    return RedirectToAction("Chat","Chat");
                }

                
            }catch(Exception ex)
            {


            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            string result = "";
            try
            {
                
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://localhost:44319/api/accounts/registeruser";
                var response = await _client.PostAsync(url, data);
                result = response.Content.ReadAsStringAsync().Result;
                if (result == "true" )
                {
                    return RedirectToAction("Chat", "Chat");
                }

            }
            catch (Exception ex)
            {


            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {

           

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
