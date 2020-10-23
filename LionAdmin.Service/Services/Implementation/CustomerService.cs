
using LionAdmin.Data.Model;
using LionAdmin.Repository.Repositories.Interface;
using LionAdmin.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionAdmin.Service.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }
        public CustomersViewModel CreateCustomer(CustomersViewModel customerViewModel)
        {
            var customer = new Customer
            {
                FirstName = customerViewModel.FirstName,
                LastName = customerViewModel.LastName,
                PhoneNumber = customerViewModel.PhoneNumber,
                Gender = customerViewModel.Gender.ToString(),
                CompanyAddress = customerViewModel.CompanyAddress,
                Description = customerViewModel.Description,
                EmailAddress = customerViewModel.EmailAddress,
                HomeAddress = customerViewModel.HomeAddress,
                Created = DateTime.Now,
                Status = 0,
            };
            _customerRepository.CreateCustomer(customer);
            return customerViewModel;
        }

        public void DeleteCustomer(string customerId)
        {
            _customerRepository.DeleteCustomer(Guid.Parse(customerId));
        }

        public CustomersViewModel GetCustomerById(string customerId)
        {
            var customer = _customerRepository.GetCustomerById(Guid.Parse(customerId));
            CustomersViewModel model = new CustomersViewModel();

            if (customer != null)
            {
                model.Id = customer.Id;
                model.FirstName = customer.FirstName;
                model.LastName = customer.LastName;
                model.PhoneNumber = customer.PhoneNumber;
                //model.Gender = customer.Gender.ToString();
                model.EmailAddress = customer.EmailAddress;
                model.CompanyAddress = customer.CompanyAddress;
                model.HomeAddress = customer.HomeAddress;
                model.Description = customer.Description;

            }
            return model;
        }

        public List<CustomersViewModel> GetCustomerList()
        {
            var list = _customerRepository.GetCustomerList();
            List<CustomersViewModel> customerList = list.Select(x => new CustomersViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                EmailAddress = x.EmailAddress,
                CompanyAddress = x.CompanyAddress,
                HomeAddress = x.HomeAddress,
                status = x.Status == 0 ? "Active" : "InActive",

            }).ToList();
            return customerList;
        }

        public void UpdateCustomer(CustomersViewModel model)
        {
            var customerGuid = model.Id;
            var editproject = _customerRepository.GetCustomerById(customerGuid);
            {
                editproject.FirstName = model.FirstName;
                editproject.LastName = model.LastName;
                editproject.PhoneNumber = model.PhoneNumber;
                editproject.Description = model.Description;
                editproject.CompanyAddress = model.CompanyAddress;
                editproject.Gender = model.Gender.ToString();
                editproject.EmailAddress = model.EmailAddress;
                editproject.HomeAddress = model.HomeAddress;
                editproject.Updated = DateTime.Now;

            }
            _customerRepository.UpdateCustomer(editproject);

        }
    }
}
