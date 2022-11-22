using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Tuskla.Models;
using Tuskla.Models.ViewModels;

namespace Tuskla.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        [Authorize]
        public ViewResult Index() => View(repository.Products.Where(p => !p.Category.StartsWith("Car") && p.isActive == true));
        public ViewResult List(string category, int page = 1)
        {
            if (category != null) {
                return View(
                    new ProductsListViewModel
                    {
                        Products = repository.Products
                            .Where(p => p.Category == category && p.isActive == true)
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = repository.Products
                                .Where(p => p.Category == category && p.isActive).Count()
                        },
                        CurrentCategory = category
                    });
            }
            else {
                return View(
                    new ProductsListViewModel
                    {
                        Products = repository.Products
                            .Where(p => !p.Category.StartsWith("Car") && p.isActive == true)
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                        PagingInfo = new PagingInfo
                        {
                            CurrentPage = page,
                            ItemsPerPage = PageSize,
                            TotalItems = repository.Products.Where(p => !p.Category.StartsWith("Car") && p.isActive == true).Count()
                        },
                        CurrentCategory = category
                    });
            }
        }
        [Authorize]
        public ViewResult Edit(int productId) => View(repository.Products.FirstOrDefault(p => p.ProductID == productId));
        [Authorize]
        [HttpPost]
        public IActionResult Edit(ProductModelView product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Edit");
            }
            else
            {
                return View(product);
            }
        }
        [Authorize]
        public ViewResult Add() => View("AddProduct", new ProductModelView());
        [Authorize]
        [HttpPost]
        public IActionResult Add(ProductModelView product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been created";
                return RedirectToAction("List");
            }
            else
            {
                return View(product);
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            ProductModelView deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}


