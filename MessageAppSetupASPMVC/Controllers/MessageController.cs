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
        public IActionResult Edit(Guid id)
        {
           


            var message = _context.Messages.FirstOrDefault(x => x.Id==id);

            EditModelDto editModelDto = new EditModelDto()
            {
              Id=message.Id,

                Text =message.Text,
                UserName =message.UserName,


            };
            if (message == null) return NotFound();
            return View(editModelDto);
        }
        [HttpPost]
        public IActionResult Edit(Guid id, EditModelDto editModelDto)

        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
           
            var message= _context.Messages.FirstOrDefault(x => x.Id == id);
            if (message== null) return NotFound();

           message.Text = editModelDto.Text;
            message.Date = DateTime.Now;
            message.IsEdited = true;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
