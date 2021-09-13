using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Services;

namespace MVCBasics.Controllers
{
    public class LanguageController : Controller
    {
        ILanguageService LS;
        public LanguageController(ILanguageService _LS)
        {
            LS = _LS;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LanguageViewModel m)
        {
            LS.Add(m.CreateLanguage);
            //return View(m);
            return RedirectToAction("Index");
        }
        public IActionResult AddToPerson(int LID,int PID)
        {
            LS.AddToPerson(LID, PID);
            return RedirectToAction("Index");
        }
        public IActionResult LanguageIndex(string search)
        {
            LanguageViewModel LVM = new LanguageViewModel();
            LVM.SearchPhrase = search;
            if (string.IsNullOrEmpty(LVM.SearchPhrase))
            {
                return PartialView("_LanguageListPartial", LS.All());
            }
            return PartialView("_LanguageListPartial", LS.FindBy(LVM));
        }
        public IActionResult LanguageDetails(int ID)
        {
            CreateLanguageViewModel LVPM = new CreateLanguageViewModel();
            LVPM.Model = LS.FindBy(ID);
            return PartialView("_LanguageDetailsPartial", LVPM);
        }
        public IActionResult Delete(int ID)
        {
            if (LS.Remove(ID))
            {
                
                ViewBag.Message = "Deleted";
                return Accepted();
                //return Json(new { success = true, responseText = "deleted" });
            }
            //return RedirectToAction("Index");
            //return Json(new { success = false, responseText = "not deleted" });
            ViewBag.Message = "Not Deleted";
            return NotFound();
        }
    }
}
