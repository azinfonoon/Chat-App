using MessageAppSetupASPMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace MessageAppSetupASPMVC.Controllers
{
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var messages=_context.Messages.ToList();
            return View(messages);
        }
    }
}
