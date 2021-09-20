using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Create(CreateRoleViewModel Model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole { Name = Model.Name };
                var result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View();
        }
    }
}
