using System;
using System.Collections.Generic;
using System.Text;

namespace LionAdmin.Service
{
    public class CustomersViewModel
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public string CompanyAddress { get; set; }
        public string HomeAddress { get; set; }
        public string status { get; set; }


    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}

