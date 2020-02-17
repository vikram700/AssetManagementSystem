using System.Collections.Generic;
using version_1.Models;
using Microsoft.AspNetCore.Mvc;
using version_1.ViewModels;

namespace version_1.Controllers
{
    public class HardwareController : Controller
    {
        private readonly IHardwareRepository _hardwareRepository;
        private readonly ILaptopRepository _laptopRepository;
        private readonly IPrinterRepository _printerRepository;
        public HardwareController(IHardwareRepository hardwareRepository, ILaptopRepository laptopRepository,
                                    IPrinterRepository printerRepository)
        {
            _hardwareRepository = hardwareRepository;
            _laptopRepository = laptopRepository;
            _printerRepository = printerRepository;
        }

        public IActionResult Details()
        {
            Dictionary<string, int> hardwareDict = _hardwareRepository.GetAllHardwares(_laptopRepository, _printerRepository);

            return View(hardwareDict);
        }
    }
}