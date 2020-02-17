using System;
using System.ComponentModel.DataAnnotations;

namespace version_1.Models
{
    public class Software : Asset
    {   
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string SoftwareName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string SoftwareCompany { get; set; }
    }
}