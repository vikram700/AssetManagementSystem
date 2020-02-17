using version_1.Models;
using Microsoft.AspNetCore.Mvc;
using version_1.ViewModels;

namespace version_1.Controllers
{
    public class SoftwareController : Controller
    {
        private readonly ISoftwareRepository _softwareRepository;

        public SoftwareController(ISoftwareRepository softwareRepository)
        {
            _softwareRepository = softwareRepository;
        }

        public IActionResult Details(string softwareName)
        {
            GenericViewModel<Software> genericViewModel = new GenericViewModel<Software>()
            {
                PageTitle = "Software Details"
            };

            if (string.IsNullOrEmpty(softwareName))
            {
                genericViewModel.AssetType = _softwareRepository.GetAllSoftwares();
            }
            else
            {
                genericViewModel.AssetType = _softwareRepository.SearchSoftware(softwareName);
            }

            return View(genericViewModel);
        }

        [HttpGet]
        public ViewResult AddNewSoftware()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewSoftware(Software newSoftware)
        {
            if(ModelState.IsValid)
            {
                _softwareRepository.AddNewSoftware(newSoftware);

                return RedirectToAction("Details");
            }
            
            return View();
        }

        [HttpGet]
        public ViewResult UpdateSoftware(int id)
        {
            Software software = _softwareRepository.GetSoftwareById(id);

            return View(software);
        }

        [HttpPost]
        public IActionResult UpdateSoftware(Software software, int id)
        {
            software.AssetId = id;

            if (ModelState.IsValid)
            {
                _softwareRepository.UpdateSoftware(software);

                return RedirectToAction("Details");
            }

            return View(software);
        }

        public IActionResult Delete(int id)
        {
            _softwareRepository.DeleteSoftware(id);

            return RedirectToAction("Details");
        }
    }
}