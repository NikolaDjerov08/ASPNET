using Microsoft.AspNetCore.Mvc;

namespace Asp_net.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
