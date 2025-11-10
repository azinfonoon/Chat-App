using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MessageAppSetupASPMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        
    }
}
