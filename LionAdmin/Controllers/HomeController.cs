using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LionAdmin.Models;
using MimeKit;
using System.Net.Mail;

namespace LionAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test project", "umariqbal047@gmail.com"));
            message.To.Add(new MailboxAddress("naren", "healthamit098@gmail.com"));
            message.Subject = "test mail in asp.net core";
            message.Body = new TextPart("Plain")
            {
                Text = "helo world mail"
            };
            //using (var client = new SmtpClient())
            //{
            //    client.Send(message);
               
            //}


                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
