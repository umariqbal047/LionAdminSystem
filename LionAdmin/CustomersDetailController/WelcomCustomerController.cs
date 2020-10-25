using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LionAdmin.CustomerController
{
    public class WelcomCustomerController : Controller
    {
        public IActionResult Index()
        {
            SendEmail();
            return View();
        }


        [HttpPost]
        public ActionResult SendEmail()
        {
            try
            {

                string receiver = "umariqbal047@gmail.com";
                string subject = "This is you'r email and password";
                string message = "message for you email";
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("umariqbal047@gmail.com");
                    var receiverEmail = new MailAddress(receiver);
                    var password = "Your Email Password here";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

    }
}
