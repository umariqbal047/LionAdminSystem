using LionAdmin.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LionAdmin.Repository.Repositories.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomerList();
        Customer GetCustomerById(Guid userId);
        Customer CreateCustomer(Customer customerModel);
        Customer UpdateCustomer(Customer updateCustomerModel);
        void DeleteCustomer(Guid customerId);
    }
}
