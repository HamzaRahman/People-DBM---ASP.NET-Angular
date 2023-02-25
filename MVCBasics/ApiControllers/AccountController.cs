using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using System.Threading.Tasks;

namespace PeopleDB.ApiControllers
{
    [Authorize]
    [ApiController]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //public IActionResult Register()
        //{
        //    return View();
        //}
       // [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.FirstName + model.LastName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Person");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        //[HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            //if (await userManager.FindByNameAsync(model.UserName)!=null)
            //{
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
            if (result.Succeeded)
            {
                return Ok();
            }
            //ModelState.AddModelError("", "Unable To Login " + result.ToString());
            return NotFound(result.ToString()+": Username or password incorrect");
            //}
            //return NotFound("User not found");

        }
        [Route("GetLoggedInUser")]
        public async Task<IActionResult> GetLoggedInUser()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Ok(await userManager.GetUserAsync(User));
            }
            return BadRequest();
        }
    }
}
