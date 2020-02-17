using System.Collections.Generic;
using System;

namespace version_1.Models
{
    public interface IHardwareRepository
    {
        Dictionary<string, int> GetAllHardwares(ILaptopRepository laptopRepository, IPrinterRepository printerRepository);
    }
}