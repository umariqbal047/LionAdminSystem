
using System;
using System.Collections.Generic;
using System.Text;

namespace LionAdmin.Service.Services.Interface
{
    public interface ICustomerService
    {
        List<CustomersViewModel> GetCustomerList();
        CustomersViewModel GetCustomerById(string customerId);
        CustomersViewModel CreateCustomer(CustomersViewModel customerViewModel);
        void UpdateCustomer(CustomersViewModel updateCustomeViewrModel);
        void DeleteCustomer(string customerId);
    }
}
