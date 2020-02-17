using System;
using System.ComponentModel.DataAnnotations;

namespace version_1.Models
{
    public class Laptop : Hardware
    {   
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string LaptopName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string CompanyName { get; set; }
        
        [Required]
        public string SerialNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string OperatingSystem { get; set; }
        
        [Required]
        [Range(0, 10, ErrorMessage = "Enter warranty period in range 0 to 10")]
        [RegularExpression(@"^\d{1,1}", ErrorMessage = "Enter valid value")]
        public int WarrantyPeriod { get; set; }
    }
}