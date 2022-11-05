using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarRental.Models
{
    
    
    public  class car
    {
       
    
        public int Id { get; set; }
        public string ModelNumber { get; set; }
        public System.DateTime ManufactureDate { get; set; }
        public string Fpicture { get; set; }
        public string Rpicture { get; set; }
        public string Lpicture { get; set; }
        public string Bpicture { get; set; }
        public int Available { get; set; }
        public string PlateNumber { get; set; }
        public int EmployeeId { get; set; }
        public int Deleted { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
        [NotMapped]
        public IFormFile LeftPicture { get; set; }
        [NotMapped]
        public IFormFile RightPicture { get; set; }
        [NotMapped]
        public IFormFile BackPicture { get; set; }


       
    
        public virtual employee employee { get; set; }
        public virtual ICollection<rent> rents { get; set; }

        
    }
}
