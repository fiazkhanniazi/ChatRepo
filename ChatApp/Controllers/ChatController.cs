using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult  Chat()
        {
            var sessionData = HttpContext.Session.GetString("UserName");
            ViewBag.userName = sessionData;
            return View();
        }
    }
}
