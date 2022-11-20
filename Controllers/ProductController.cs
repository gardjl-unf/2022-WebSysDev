using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    }
}


