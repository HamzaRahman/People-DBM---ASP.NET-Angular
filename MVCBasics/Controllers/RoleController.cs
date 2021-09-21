using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var Roles = roleManager.Roles.ToList();
            return View(Roles);
        }
        public IActionResult Create() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel Model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole { Name = Model.Name };
                var result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string ID)
        {
            CreateRoleViewModel CRVM = new CreateRoleViewModel();
            var role = await roleManager.FindByIdAsync(ID);
            CRVM.ID = role.Id;
            CRVM.Name = role.Name;
            foreach(var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    CRVM.RoleUsers.Add(user);
                }
            }
            return View(CRVM);
        }
    }
}
