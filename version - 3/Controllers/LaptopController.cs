using version_1.Models;
using Microsoft.AspNetCore.Mvc;
using version_1.ViewModels;

namespace version_1.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ILaptopRepository _laptopRepository;

        public LaptopController(ILaptopRepository laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        public IActionResult Details(string laptopName)
        {
            GenericViewModel<Laptop> genericViewModel = new GenericViewModel<Laptop>()
            {
                PageTitle = "Hardware Details"
            };

            if (string.IsNullOrEmpty(laptopName))
            {
                genericViewModel.AssetType = _laptopRepository.GetAllLaptops();
            }
            else
            {
                genericViewModel.AssetType = _laptopRepository.SearchLaptop(laptopName);
            }

            return View(genericViewModel);
        }

        [HttpGet]
        public ViewResult AddNewLaptop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewLaptop(Laptop newLaptop)
        {
            if(ModelState.IsValid)
            {
                _laptopRepository.AddNewLaptop(newLaptop);

                return RedirectToAction("Details");
            }
            
            return View();
        }

        [HttpGet]
        public ViewResult UpdateLaptop(int id)
        {
            Laptop laptop = _laptopRepository.GetLaptopById(id);

            return View(laptop);
        }

        [HttpPost]
        public IActionResult UpdateLaptop(Laptop laptop, int id)
        {
            laptop.AssetId = id;

            if (ModelState.IsValid)
            {
                _laptopRepository.UpdateLaptop(laptop);

                return RedirectToAction("Details");
            }

            return View(laptop);
        }

        public IActionResult Delete(int id)
        {
            _laptopRepository.DeleteLaptop(id);

            return RedirectToAction("Details");
        }
    }
}