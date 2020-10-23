using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LionAdmin.CustomerController
{
    public class WelcomCustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
