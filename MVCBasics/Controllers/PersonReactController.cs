using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Controllers
{
    public class PersonReactController : Controller
    {
        IPeopleService ps;
        private readonly ICityService CS;
        private readonly ILanguageService lS;
        PeopleViewModel PV = new PeopleViewModel();
        public PersonReactController(IPeopleService _ps, ICityService _CS, ILanguageService LS)
        {
            ps = _ps;
            CS = _CS;
            lS = LS;
        }
        public async Task<IActionResult> People()
        {
            //PV.AllCities = CS.All().Cities;
            //PV.people = ps.All().people;
            //var pvm = await lS.All();
            //PV.AllLanguages = pvm.Languages;
            
            return View(ps.All());
        }
        
        //[ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return Json(ps.All());
        }
    }
}
