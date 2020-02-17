using System;
using System.ComponentModel.DataAnnotations;

namespace version_1.Models
{
    public class Hardware : Asset
    {   
        public string HardwareType { get; set; }
    }
}