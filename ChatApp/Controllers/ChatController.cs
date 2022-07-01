using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult  Chat()
        {
           
            return View();
        }
    }
}
