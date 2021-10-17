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
        public IActionResult Index()
        {
            return View(ps.All());
        }
        public IActionResult People()
        {
            return Json(ps.All());
        }
    }
}
