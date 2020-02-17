using System;
using System.ComponentModel.DataAnnotations;

namespace version_1.Models
{
    public class Printer : Hardware
    {   
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string PrinterName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string CompanyName { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string PrinterType { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string PrinterQuality { get; set; }
    }
}