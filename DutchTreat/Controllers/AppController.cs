using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private IMailService _mailService;

        public AppController(IMailService mailservice)
        {
            _mailService = mailservice;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("contact")]
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact us";
            //throw new InvalidOperationException("Upps"); 

            return View();
        }
        [HttpPost("contact")]
        public ActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("p@gmail.com", model.Subject, model.Message);
                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();
            }
           
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }
    }
}
