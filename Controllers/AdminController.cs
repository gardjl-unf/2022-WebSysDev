using Microsoft.AspNetCore.Mvc;
using Tuskla.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.AspNetCore.Identity;
using Tuskla.Models.ViewModels;

namespace Tuskla.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        UserManager<AppUser> userManager;
        public AdminController(IProductRepository repo, UserManager<AppUser> userMgr )
        {
            repository = repo;
            userManager = userMgr;
        }

        public ViewResult ListAllProducts() => View(repository.Products.Where(p => !p.Category.StartsWith("Car") && p.isActive == true));

        public ViewResult ProductToEdit() => View(repository.Products.Where(p => !p.Category.StartsWith("Car") && p.isActive == true));

        public ViewResult DeleteProduct() => View(repository.Products.Where(p => !p.Category.StartsWith("Car") && p.isActive == true));


        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));
        
        [HttpPost]
        public IActionResult Edit(ProductModelView product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("ProductToEdit");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }
        public ViewResult AddProduct() => View("AddProduct", new ProductModelView());

        [HttpPost]
        public IActionResult AddProduct(ProductModelView product)
        {
            if (ModelState.IsValid)

            {
                
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("ListAllProducts");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }


        [HttpPost]
        public IActionResult Delete(int productId)
        {
            ProductModelView deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("DeleteProduct");
        }
        public ViewResult MainAdmin()
        {
            return View("MainAdmin");
        }
        [HttpPost]
        public async void ChangePassword(string email, string password)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            await userManager.ResetPasswordAsync(user, token, password);
        }
        [HttpPost]
        public async void ChangeEmail(string email, string newEmail)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await userManager.GenerateChangeEmailTokenAsync(user, newEmail);
                await userManager.ChangeEmailAsync(user, email, token);
                await userManager.UpdateNormalizedEmailAsync(user);
            }
        }
    }
}
