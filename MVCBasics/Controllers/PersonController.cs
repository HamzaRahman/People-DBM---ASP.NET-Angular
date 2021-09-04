using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCBasics.Controllers
{
    public class PersonController : Controller
    {
        //Constructor Injection--Fetching IPeopleService Object from Startup ConfigureServices
        IPeopleService ps;
        public PersonController(IPeopleService _ps)
        {
            ps = _ps;
        }
        public IActionResult Index(PeopleViewModel search)
        {
            if (string.IsNullOrEmpty(search.SearchPhrase))
            {
                return View(ps.All());
            }
            return View(ps.FindBy(search));
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePersonViewModel m)
        {
            ps.Add(m);
            return View(m);
        }
        public IActionResult Edit(int ID)
        {
            CreatePersonViewModel CVPM = new CreatePersonViewModel();
            CVPM.Model = ps.FindBy(ID); 
            return View(CVPM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreatePersonViewModel p)
        {
            ps.Edit(p.ID, p.Model);
            return View(p);
        }
        public IActionResult Delete(int ID)
        {
            if(ps.Remove(ID))
            {
                //return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!');</script>");
                ViewBag.Message = "Deleted";
                return Accepted();
                //return Json(new { success = true, responseText = "deleted" });
            }
            //return RedirectToAction("Index");
            //return Json(new { success = false, responseText = "not deleted" });
            ViewBag.Message = "Not Deleted";
            return NotFound();
        }

        ///////////////////////// ACTIONS for AJAX
        ///
        public IActionResult PeopleIndex(string search)
        {
            PeopleViewModel PVM = new PeopleViewModel();
            PVM.SearchPhrase = search;
            if (string.IsNullOrEmpty(PVM.SearchPhrase))
            {
                return PartialView("_PeopleIndex", ps.All());
            }
            return PartialView("_PeopleIndex", ps.FindBy(PVM));
        }
        public IActionResult PersonDetails(int ID)
        {
            CreatePersonViewModel CVPM = new CreatePersonViewModel();
            CVPM.Model = ps.FindBy(ID);
            return PartialView("_PersonDetails",CVPM);
        }
        //public IActionResult GetData()
        //{
        //    var all = ps.All();
        //    List<Person> people = new List<Person>();
        //    people = all.people;
        //    Person p = new Person();
        //    p.ID = 1;
        //    p.Name = "Hamza";
        //    p.PhoneNumber = 00;
        //    p.city = "dff";
        //    people.Add(p);
        //    return PartialView("_Person",people.Last());
        //}
    }
}
