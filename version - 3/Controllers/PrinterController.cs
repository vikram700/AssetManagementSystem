using version_1.Models;
using Microsoft.AspNetCore.Mvc;
using version_1.ViewModels;

namespace version_1.Controllers
{
    public class PrinterController : Controller
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterController(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }

        public IActionResult Details(string printerName)
        {
            GenericViewModel<Printer> genericViewModel = new GenericViewModel<Printer>()
            {
                PageTitle = "Hardware Details"
            };

            if (string.IsNullOrEmpty(printerName))
            {
                genericViewModel.AssetType = _printerRepository.GetAllPrinters();
            }
            else
            {
                genericViewModel.AssetType = _printerRepository.SearchPrinter(printerName);
            }

            return View(genericViewModel);
        }

        [HttpGet]
        public ViewResult AddNewPrinter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPrinter(Printer newPrinter)
        {
            if(ModelState.IsValid)
            {
                _printerRepository.AddNewPrinter(newPrinter);

                return RedirectToAction("Details");
            }
            
            return View();
        }

        [HttpGet]
        public ViewResult UpdatePrinter(int id)
        {
            Printer printer = _printerRepository.GetPrinterById(id);

            return View(printer);
        }

        [HttpPost]
        public IActionResult UpdatePrinter(Printer printer, int id)
        {
            printer.AssetId = id;

            if (ModelState.IsValid)
            {
                _printerRepository.UpdatePrinter(printer);

                return RedirectToAction("Details");
            }

            return View(printer);
        }

        public IActionResult Delete(int id)
        {
            _printerRepository.DeletePrinter(id);

            return RedirectToAction("Details");
        }
    }
}