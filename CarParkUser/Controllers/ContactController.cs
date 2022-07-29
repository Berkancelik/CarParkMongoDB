using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CarParkUser.Controllers
{
    public class ContactController : Controller
    {
        private IStringLocalizer<SharedResources> _localizer;

        public ContactController(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var welcome_calue = _localizer["Welcome"];
            return View();
        }
    }
}
