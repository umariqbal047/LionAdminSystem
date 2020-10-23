using LionAdmin.Data.ApplicationDbContext;
using LionAdmin.Data.Model;
using LionAdmin.Repository.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LionAdmin.Repository.Repositories.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }
        public Customer CreateCustomer(Customer customerModel)
        {

            _context.customers.Add(customerModel);
            _context.SaveChanges();
            return customerModel;
        }

        public void DeleteCustomer(Guid customerId)
        {

            Customer customerById = _context.customers.FirstOrDefault(a => a.Id == customerId);
            if (customerById != null)
            {
                customerById.Status = 1;
                _context.SaveChanges();
            }
        }

        public Customer GetCustomerById(Guid userId)
        {
            Customer customerToReturn = (from a in _context.customers
                                         where !a.IsDeleted && a.Id == userId
                                         select new Customer()
                                         {
                                             Id = a.Id,
                                             Created=a.Created,
                                             Updated=a.Updated,
                                             FirstName=a.FirstName,
                                             LastName=a.LastName,
                                             PhoneNumber=a.PhoneNumber,
                                             Gender=a.Gender,
                                             Description=a.Description,
                                             EmailAddress=a.EmailAddress,
                                             CompanyAddress=a.CompanyAddress,
                                             HomeAddress=a.HomeAddress
                                             
                                         }).FirstOrDefault();
            return customerToReturn;
        }

        public List<Customer> GetCustomerList()
        {
            List<Customer> customerList = _context.customers.Where(x => x.IsDeleted == false).ToList();
            return customerList;
        }

        public Customer UpdateCustomer(Customer updateCustomerModel)
        {
           
            _context.customers.Update(updateCustomerModel);
            _context.SaveChanges();
            return updateCustomerModel;
        }
    }
}
