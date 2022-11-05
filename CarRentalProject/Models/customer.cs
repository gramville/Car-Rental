using System;
using System.Collections.Generic;

namespace CarRental.Models
{
    
    
    public  class customer
    {
        
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Deleted { get; set; }

        public virtual ICollection<rent> rents { get; set; }
    }
}
