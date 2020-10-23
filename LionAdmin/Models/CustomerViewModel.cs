using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LionAdmin.Models
{
    public class CustomerViewModel
    {
        
            public Guid Id { get; set; }
            public string Created { get; set; }
            public string Updated { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public Gender Gender { get; set; }
            public string Description { get; set; }
            public string EmailAddress { get; set; }
            public string CompanyAddress { get; set; }
       
       
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
