using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LionAdmin.Models;
using LionAdmin.Service;
using LionAdmin.Service.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LionAdmin.Controllers
{
   // [Authorize]
    public class CustomerController : Controller
    {
        private ICustomerService _customerServices;

        public CustomerController(ICustomerService customerService)
        {
            _customerServices = customerService;
        }
        public IActionResult Index()
        
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(CustomersViewModel model)
        {
           var result= _customerServices.CreateCustomer(model);
            return Json(result);
        }

        public JsonResult GetAllCustomer(DataTablesParam param, string EName)
        {
            try
            {
                //List<BookingViewModel> List = new List<BookingViewModel>();
                int pageNo = 1;
                if (param.iDisplayStart >= param.iDisplayLength)
                {
                    pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;
                }

                var List = _customerServices.GetCustomerList();


                int totalCount = 0;
                if (param.sSearch != null)
                {
                    totalCount = List.Where(x => (!string.IsNullOrEmpty(x.FirstName) && x.FirstName.ToLower().Contains(param.sSearch.ToLower()))
                     || (!string.IsNullOrEmpty(x.PhoneNumber.ToString()) && x.PhoneNumber.ToString().Contains(param.sSearch.ToString()))
                     || (!string.IsNullOrEmpty(x.status.ToString()) && x.status.ToString().Contains(param.sSearch.ToString()))
                     || (!string.IsNullOrEmpty(x.CompanyAddress.ToString()) && x.CompanyAddress.ToString().Contains(param.sSearch.ToString()))
                     || (!string.IsNullOrEmpty(x.HomeAddress.ToString()) && x.HomeAddress.ToString().Contains(param.sSearch.ToString()))
                     || x.CompanyAddress.ToString().Contains(param.sSearch)
                     ).Count();

                    List = List.Where(x => (x.FirstName != null && x.FirstName.ToLower().Contains(param.sSearch.ToLower()))
                    || (!string.IsNullOrEmpty(x.PhoneNumber.ToString()) && x.PhoneNumber.ToString().Contains(param.sSearch.ToString()))
                    || (!string.IsNullOrEmpty(x.status.ToString()) && x.status.ToString().Contains(param.sSearch.ToString()))
                    || (!string.IsNullOrEmpty(x.CompanyAddress.ToString()) && x.CompanyAddress.ToString().Contains(param.sSearch.ToString()))
                    || (!string.IsNullOrEmpty(x.HomeAddress.ToString()) && x.HomeAddress.ToString().Contains(param.sSearch.ToString()))
                    || x.CompanyAddress.ToString().Contains(param.sSearch)
                    )
                        .OrderBy(x => x.FirstName)
                        .Skip((pageNo - 1) * param.iDisplayLength)
                        .Take(param.iDisplayLength).ToList();
                }
                else
                {
                    totalCount = List.Count();
                    List = List.OrderByDescending(x => x.FirstName)
                        .Skip((pageNo - 1) * param.iDisplayLength)
                        .Take(param.iDisplayLength).ToList();
                }
                return Json(new
                {
                    aaData = List.Select(a => new
                    {
                        id = a.Id,
                        firstName = a.FirstName,
                        lastName = a.LastName,
                        phonNo = a.PhoneNumber,
                        email = a.EmailAddress,
                        companyAddress = a.CompanyAddress,
                        customerStatus=a.status,
                        homeAddress=a.HomeAddress
                    }),
                    sEcho = param.sEcho,
                    iTotalDisplayRecords = totalCount,
                    iTotalRecords = totalCount

                }); ;
            }
            catch (Exception e)
            {
                //Log.WriteLog("GetAllBooking Types  exception " + e.ToString());

                return null;
            }

        }

        //public IActionResult GetCustomerById(string GetCustomerById)
        //{
        //    return RedirectToAction("Eidt", "Customer", new { Id = customerId });
        //}
        public IActionResult GetCustomerById(string customerId)
        {
            var model= _customerServices.GetCustomerById(customerId);
           // return Json(model);
            return PartialView("_EditCustomer", model);
        }
        [HttpPost]
        public IActionResult Edit(CustomersViewModel model)
        {
            var res = "";
            var customr=_customerServices.UpdateCustomer(model);
            if (customr !=null)
                return Json(customr);


            return Json(res);
        }

        [HttpPost]
        public IActionResult DisableCustomer(string Id)
        {
            var result = "success";

           _customerServices.DeleteCustomer(Id);
            return Json(result);
        }




    }
}
