using MessageAppSetupASPMVC.Data;
using MessageAppSetupASPMVC.Models;
using MessageAppSetupASPMVC.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateModelDto createModelDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createModelDto);
            }
            Message message = new Message()
            {   
                Id=Guid.NewGuid(),
                UserName=createModelDto.UserName,
                Text=createModelDto.Text,
                Date=DateTime.Now,
                IsEdited=false,
                
            };
           _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
