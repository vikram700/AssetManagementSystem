using System.Reflection;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace version_1.Models
{   
    public class HardwareRepository : IHardwareRepository
    {   
        public Dictionary<string, int> GetAllHardwares(ILaptopRepository laptopRepository, IPrinterRepository printerRepository)
        {   
            Dictionary<string, int> hardwareDict = new Dictionary<string, int>();

            hardwareDict["Laptops"] = laptopRepository.TotalLaptops();
            hardwareDict["Printers"] = printerRepository.TotalPrinters();

            return hardwareDict;
        }
    }
}