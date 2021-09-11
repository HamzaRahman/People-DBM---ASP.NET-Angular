using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Controllers
{
    public class CityController : Controller
    {
        ICityService CS;
        public CityController(ICityService _CS)
        {
            CS = _CS;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CityViewModel m)
        {
            CS.Add(m.CreateCity);
            //return View(m);
            return RedirectToAction("Index");
        }
        public IActionResult CityIndex(string search)
        {
            CityViewModel CVM = new CityViewModel();
            CVM.SearchPhrase = search;
            if (string.IsNullOrEmpty(CVM.SearchPhrase))
            {
                return PartialView("_CityListPartial", CS.All());
            }
            return PartialView("_CityListPartial", CS.FindBy(CVM));
        }
        public IActionResult CityDetails(int ID)
        {
            CreateCityViewModel CVPM = new CreateCityViewModel();
            CVPM.Model = CS.FindBy(ID);
            return PartialView("_CityDetailsPartial", CVPM);
        }
        public IActionResult Delete(int ID)
        {
            if (CS.Remove(ID))
            {
                ViewBag.Message = "Deleted";
                return Accepted();
            }
            ViewBag.Message = "Not Deleted";
            return NotFound();
        }
    }
}
