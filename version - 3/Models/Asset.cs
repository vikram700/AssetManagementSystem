using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System;

namespace version_1.Models
{
    public class Asset
    {   
        public int AssetId { get; set; }

        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{0,4})?$", ErrorMessage = "Enter the valid price")]
        public double AssetPrice { get; set; }
        
    }
}