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
        PeopleService ps = new PeopleService();
        public IActionResult Index(PeopleViewModel search)
        {
            if(string.IsNullOrEmpty(search.Name))
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
        public ActionResult Delete(int ID)
        {
            ps.Remove(ID);
            return RedirectToAction("Index");
        }
    }
}
