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
        public int PageSize = 14;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult IndexModelStart(string Model)
        {
            Model = "Model 3 Plaid";


            ViewBag.Logo = "..//img//" + Model.Substring(0, 5) + Model.Substring(6, 1) + Model.Substring(8) + ".jpg";
            ViewBag.ModelType = Model.Substring(0, 7);
            ViewBag.ModelTypeBtn1 = Model.Substring(0, 7) + " Standard";
            ViewBag.ModelTypeBtn2 = Model.Substring(0, 7) + " Plaid";
            return View("Index");
        }

        public ViewResult IndexModel(string Model)
        {

            ViewBag.Logo = "..//img//" + Model.Substring(0, 5) + Model.Substring(6, 1) + Model.Substring(8) + ".jpg";
            ViewBag.ModelType = Model.Substring(0, 7);
            ViewBag.ModelTypeBtn1 = Model.Substring(0, 7) + " Standard";
            ViewBag.ModelTypeBtn2 = Model.Substring(0, 7) + " Plaid";
            return View("Index");
        }

        public ViewResult PurchaseModel(string Model)
        {

            ViewBag.Logo = "..//img//" + Model.Substring(0, 5) + Model.Substring(6, 1) + Model.Substring(8) + ".jpg";
            ViewBag.Model = Model;

            switch (Model)
            {
                case "Model 3 Standard":
                    ViewBag.Delivery = "Delivery Oct 2022 - Dec 2022";
                    ViewBag.Price = "Purchase Price $46,500";
                    ViewBag.Savings = "Potential Savings* $6,000";
                    ViewBag.Range = "Range 267mi - 312mi (est.)";
                    ViewBag.Speed = "Top Speed 140mph";
                    ViewBag.Acceleration1 = "Acceleraion 0-60 mph";
                    ViewBag.Acceleration2 = "5.8sec";
                    ViewBag.Drive = "Rear-Wheel Drive";
                    break;

                case "Model 3 Plaid":
                    ViewBag.Delivery = "Delivery Nov 2022 - Jan 20222";
                    ViewBag.Price = "Purchase Price $61,600";
                    ViewBag.Savings = "Potential Savings* $6,000";
                    ViewBag.Range = "Range 267mi - 312mi (est.)";
                    ViewBag.Speed = "Top Speed 160mph";
                    ViewBag.Acceleration1 = "Acceleraion 0-60 mph";
                    ViewBag.Acceleration2 = "3.1Sec";
                    ViewBag.Drive = "Rear-Wheel Drive";
                    break;


                case "Model Y Standard":
                    ViewBag.Delivery = "Delivery Oct 2022 - Dec 2022";
                    ViewBag.Price = "Purchase Price $61,300 - $85,600";
                    ViewBag.Savings = "Potential Savings* $6,000";
                    ViewBag.Range = "Range 267mi - 312mi (est.)";
                    ViewBag.Speed = "Top Speed 140mph";
                    ViewBag.Acceleration1 = "Acceleraion 0-60 mph";
                    ViewBag.Acceleration2 = "5.8sec";
                    ViewBag.Drive = "Rear-Wheel Drive";
                    break;

                case "Model Y Plaid":
                    ViewBag.Delivery = "Delivery Nov 2022 - Jan 2023";
                    ViewBag.Price = "Purchase Price $85,600";
                    ViewBag.Savings = "Potential Savings* $6,000";
                    ViewBag.Range = "Range 267mi - 312mi (est.)";
                    ViewBag.Speed = "Top Speed 160mph";
                    ViewBag.Acceleration1 = "Acceleraion 0-60 mph";
                    ViewBag.Acceleration2 = "3.1Sec";
                    ViewBag.Drive = "Rear-Wheel Drive";
                    break;

                case "Model X Standard":
                    ViewBag.Delivery = "Delivery Oct 2022 - Dec 2022";
                    ViewBag.Price = "Purchase Price $120,500";
                    ViewBag.Savings = "Potential Savings* $6,000";
                    ViewBag.Range = "Range 267mi - 312mi (est.)";
                    ViewBag.Speed = "Top Speed 140mph -160mph";
                    ViewBag.Acceleration1 = "Acceleraion 0-60 mph";
                    ViewBag.Acceleration2 = "3.1Sec - 5.8sec";
                    ViewBag.Drive = "Rear-Wheel Drive";
                    break;

                case "Model X Plaid":
                    ViewBag.Delivery = "Delivery Nov 2022 - Jan 2023";
                    ViewBag.Price = "Purchase Price $145,600";
                    ViewBag.Savings = "Potential Savings* $6,000";
                    ViewBag.Range = "Range 267mi - 312mi (est.)";
                    ViewBag.Speed = "Top Speed 160mph";
                    ViewBag.Acceleration1 = "Acceleraion 0-60 mph";
                    ViewBag.Acceleration2 = "3.1Sec";
                    ViewBag.Drive = "Rear-Wheel Drive";
                    break;

                case "Model S Standard":
                    ViewBag.Delivery = "Delivery Oct 2022 - Dec 2022";
                    ViewBag.Price = "Purchase Price $120,100 - $141,700";
                    ViewBag.Savings = "Potential Savings* $6,000";
                    ViewBag.Range = "Range 267mi - 312mi (est.)";
                    ViewBag.Speed = "Top Speed 140mph -160mph";
                    ViewBag.Acceleration1 = "Acceleraion 0-60 mph";
                    ViewBag.Acceleration2 = "3.1Sec - 5.8sec";
                    ViewBag.Drive = "Rear-Wheel Drive";
                    break;

                case "Model S Plaid":
                    ViewBag.Delivery = "Delivery Nov 2022 - Jan 2023";
                    ViewBag.Price = "Purchase Price $141,700";
                    ViewBag.Savings = "Potential Savings* $6,000";
                    ViewBag.Range = "Range 267mi - 312mi (est.)";
                    ViewBag.Speed = "Top Speed 160mph";
                    ViewBag.Acceleration1 = "Acceleraion 0-60 mph";
                    ViewBag.Acceleration2 = "2.9Sec";
                    ViewBag.Drive = "Rear-Wheel Drive";
                    break;

                default:
                    break;

            }

            return View("PurchaseModel");
        }

        //The below is called for general merchandise

        public ViewResult List(string category, int page = 1) => View(new ProductsListViewModel
        {
            Products = repository.Products
                .Where(p => category != null && p.Category == category && !p.Category.StartsWith("Cars") && p.isActive == true)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
            },
            CurrentCategory = category
        });

        //The below is called for adding a vehicle and vehicle options
        public ViewResult AddVehicleItem(string category, int page = 1)
        {

            if (category.Substring(0, 3) == "Mod")
            {
                ViewBag.Next = "Paint";
            }
            else
            {

                switch (category)
                {
                    case "Paint":
                        ViewBag.Next = "Interior";
                        break;

                    case "Interior":
                        ViewBag.Next = "Rims";
                        break;

                    case "Rims":
                        ViewBag.Next = "AutoPilot";
                        break;

                    case "AutoPilot":
                        ViewBag.Next = "FullSelfDriving";
                        break;

                    default:
                        break;

                }
            }

            return View(new ProductsListViewModel
            {
                Products =
            repository.Products
            .Where((p => p.Name == category))
            .OrderBy(p => p.ProductID)
            .Skip((page - 1) * PageSize)

            });
        }

 
    }
}


