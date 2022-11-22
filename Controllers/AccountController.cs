using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Tuskla.Models.ViewModels;
using Tuskla.Models;

namespace Tuskla.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/ListAllProducts");
                    }
                    
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        public async Task<RedirectToRouteResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToRoute(new { controller = "Vehicle", action = "Index", Model = "Model 3 Standard" });
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            return View(userManager.Users);
        }
        [AllowAnonymous]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(await userManager.FindByEmailAsync(model.Email) == null))
                {
                    ModelState.AddModelError("", "Email already in use");
                    return View(model);
                }
                AppUser user = new AppUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            
        foreach (IdentityError error in result.Errors)
            {
                ModelState.TryAddModelError("", error.Description);
            }
        }
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrors(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View("Index", userManager.Users);
        }
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string email, string password)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (password == null)
            {
                TempData["message"] = $"Cannot set {user.UserName}'s password to a blank password!";
                return RedirectToAction("Edit", "Account");
            }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var status = await userManager.ResetPasswordAsync(user, token, password);

            if (status.Succeeded)
            {
                TempData["message"] = $"{user.UserName}'s password has been changed";
                return RedirectToAction("Index", "Account");
            }
            foreach (IdentityError error in status.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction("Index", "Account");
    }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeEmail(string email, string newEmail)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (newEmail == null)
            {
                TempData["message"] = $"Cannot set {user.UserName}'s email address to a blank email address!";
                return RedirectToAction("Index", "Account");
            }

            var token = await userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            var status = await userManager.ChangeEmailAsync(user, newEmail, token);
            await userManager.UpdateNormalizedEmailAsync(user);

            if (status.Succeeded)
            {
                TempData["message"] = $"{user.UserName}'s email address has been changed from {email} to {newEmail}";
                return RedirectToAction("Index", "Account");
            }
            foreach (IdentityError error in status.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction("Index", "Account");
        }
    }
}