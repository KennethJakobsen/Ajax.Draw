using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Acme_Draw.Controllers
{
    public class ProductRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
