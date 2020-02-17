using System.ComponentModel.DataAnnotations;
using System;

namespace version_1.Models
{
    public class Book : Asset
    {    
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string BookTitle { get; set; }

        [Required]
         [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string BookAuthorName { get; set; }

        [Required]
         [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter the valid name")]
        public string BookPublisher { get; set; }

        [Required]
        [Range(1000, 2020, ErrorMessage = "Enter year in range 1000 to 2020")]
        [RegularExpression(@"^\d{4,4}", ErrorMessage = "Enter corret year")]
        public int BookPublishedYear { get; set; }
    }
}