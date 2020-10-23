using System;
using System.Collections.Generic;
using System.Text;

namespace LionAdmin.Data.Model
{
    public class Customer
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string EmailAddress { get; set; }
        public string CompanyAddress { get; set; }
        public string HomeAddress { get; set; }
    }
   
}
