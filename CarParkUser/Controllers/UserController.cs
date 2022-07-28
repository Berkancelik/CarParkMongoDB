using Microsoft.AspNetCore.Mvc;

namespace CarParkUser.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
