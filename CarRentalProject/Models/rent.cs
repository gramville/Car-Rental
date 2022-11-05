using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CarRental.Models
{

    
    public  class rent
    {

        public int Id { get; set; } 
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int Fare { get; set; }
        public double TotalAmount { get; set; }
        public int Returned { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        [NotMapped]
        public string ModelNumber { get; set; }
        [NotMapped]
        public System.DateTime ManufactureDate { get; set; }
        [NotMapped]
        public string PlateNumber { get; set; }
        [NotMapped]
        public string FPicture { get; set; }
        [NotMapped]
        public string RPicture { get; set; }
        [NotMapped]
        public string LPicture { get; set; }
        [NotMapped]
        public string BPicture { get; set; }

        public virtual car car { get; set; }
        public virtual customer customer { get; set; }
    }
}
