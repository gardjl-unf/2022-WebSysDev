using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EVehiclesB.Models;
using EVehiclesB.Models.ViewModels;
namespace EVehiclesB.Controllers
{

    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 14;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }


        public ViewResult IndexModel3()
        {
            ViewBag.Logo = "..//img//model3.jpg";
            ViewBag.Model = "Model 3";
            ViewBag.ModelPurchase = "PurchaseModel3";


            return View("Index");
        }

        public ViewResult IndexModelY()
        {
            ViewBag.Logo = "..//img//modelY.jpg";
            ViewBag.Model = "Model Y";
            ViewBag.ModelPurchase = "PurchaseModelY";

            return View("Index");
        }

        public ViewResult IndexModelX()
        {
            ViewBag.Logo = "..//img//modelX.jpg";
            ViewBag.Model = "Model X";
            ViewBag.ModelPurchase = "PurchaseModelX";

            return View("Index");
        }

        public ViewResult IndexModelS()
        {
            ViewBag.Logo = "..//img//modelS.jpg";
            ViewBag.Model = "Model S";
            ViewBag.ModelPurchase = "PurchaseModelS";

            return View("Index");
        }

        public ViewResult PurchaseModel3()

        {

            ViewBag.Logo = "..//img//model3.jpg";
            ViewBag.Model = "Model 3";

            ViewBag.Line1 = "Delivery Oct 2022 - Dec 2022";
            ViewBag.Line2 = "Purchase Price $46,500 - $61,600";
            ViewBag.Line3 = "Potential Savings* $6,000";
            ViewBag.Line4 = "Range 267mi - 312mi (est.)";
            ViewBag.Line5 = "Top Speed 140mph -160mph";
            ViewBag.Line6 = "Acceleraion 0-60 mph";
            ViewBag.Line7 = "3.1Sec - 5.8sec";
            ViewBag.Line8 = "Rear-Wheel Drive";

            ViewBag.purchaseStd = "List1";
            ViewBag.purchasePlaid = "List2";

            ViewBag.buttonStandard = "Model 3 Standard";
            ViewBag.buttonPlaid = "Model 3 Plaid";

            return View("PurchaseModel");
        }

        public ViewResult PurchaseModelY()

        {

            ViewBag.Logo = "..//img//modelY.jpg";
            ViewBag.Model = "Model Y";

            ViewBag.Line1 = "Delivery Oct 2022 - Dec 2022";
            ViewBag.Line2 = "Purchase Price $63,500 - $68,600";
            ViewBag.Line3 = "Potential Savings* $6,000";
            ViewBag.Line4 = "Range 267mi - 312mi (est.)";
            ViewBag.Line5 = "Top Speed 140mph -160mph";
            ViewBag.Line6 = "Acceleraion 0-60 mph";
            ViewBag.Line7 = "3.1Sec - 5.8sec";
            ViewBag.Line8 = "Rear-Wheel Drive";

            ViewBag.purchaseStd = "List3";
            ViewBag.purchasePlaid = "List4";

            ViewBag.buttonStandard = "Model Y Standard";
            ViewBag.buttonPlaid = "Model Y Plaid";


            return View("PurchaseModel");

        }

        public ViewResult PurchaseModelX()

        {

            ViewBag.Logo = "..//img//modelX.jpg";
            ViewBag.Model = "Model X";

            ViewBag.Line1 = "Delivery Oct 2022 - Dec 2022";
            ViewBag.Line2 = "Purchase Price $130,500 - $155,600";
            ViewBag.Line3 = "Potential Savings* $6,000";
            ViewBag.Line4 = "Range 267mi - 312mi (est.)";
            ViewBag.Line5 = "Top Speed 160mph -180mph";
            ViewBag.Line6 = "Acceleraion 0-60 mph";
            ViewBag.Line7 = "2.9Sec - 3.2sec";
            ViewBag.Line8 = "Rear-Wheel Drive";

            ViewBag.purchaseStd = "List5";
            ViewBag.purchasePlaid = "List6";

            ViewBag.buttonStandard = "Model X Standard";
            ViewBag.buttonPlaid = "Model X Plaid";


            return View("PurchaseModel");

        }

        public ViewResult PurchaseModelS()

        {

            ViewBag.Logo = "..//img//modelS.jpg";
            ViewBag.Model = "Model S";

            ViewBag.Line1 = "Delivery Oct 2022 - Dec 2022";
            ViewBag.Line2 = "Purchase Price $124,500 - $144,600";
            ViewBag.Line3 = "Potential Savings* $6,000";
            ViewBag.Line4 = "Range 267mi - 312mi (est.)";
            ViewBag.Line5 = "Top Speed 160mph -180mph";
            ViewBag.Line6 = "Acceleraion 0-60 mph";
            ViewBag.Line7 = "2.8sec - 3.2sec";
            ViewBag.Line8 = "Rear-Wheel Drive";

            ViewBag.purchaseStd = "List7";
            ViewBag.purchasePlaid = "List8";

            ViewBag.buttonStandard = "Model S Standard";
            ViewBag.buttonPlaid = "Model S Plaid";

            return View("PurchaseModel");

        }


        public ViewResult List(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where(p => category != null || p.Category == "Interior")
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?
       
       
        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });

/* All of the below nonsense could be removed if the above query
.Where(p => category == null || p.Category == category)
could be replaced with a string variable that is reurned from the view that calls it
*/

       public ViewResult List1(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where((p => p.Name.StartsWith("Interior") || p.Name == ("Model 3 Standard")
        || p.Name == ("Paint") || p.Name == ("Rims")
        || p.Name == ("AutoPilot") || p.Name == ("FullSelfDriving")))
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?


        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });

       public ViewResult List2(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where((p => p.Name.StartsWith("Interior") || p.Name == ("Model 3 Plaid")
        || p.Name == ("Paint") || p.Name == ("Rims")
        || p.Name == ("AutoPilot") || p.Name == ("FullSelfDriving")))
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?


        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });

       public ViewResult List3(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where((p => p.Name.StartsWith("Interior") || p.Name == ("Model Y Standard")
        || p.Name == ("Paint") || p.Name == ("Rims")
        || p.Name == ("AutoPilot") || p.Name == ("FullSelfDriving")))
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?


        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });

       public ViewResult List4(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where((p => p.Name.StartsWith("Interior") || p.Name == ("Model Y Plaid")
        || p.Name == ("Paint") || p.Name == ("Rims")
        || p.Name == ("AutoPilot") || p.Name == ("FullSelfDriving")))
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?


        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });

       public ViewResult List5(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where((p => p.Name.StartsWith("Interior") || p.Name == ("Model X Standard")
        || p.Name == ("Paint") || p.Name == ("Rims")
        || p.Name == ("AutoPilot") || p.Name == ("FullSelfDriving")))
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?


        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });

       public ViewResult List6(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where((p => p.Name.StartsWith("Interior") || p.Name == ("Model Y Plaid")
        || p.Name == ("Paint") || p.Name == ("Rims")
        || p.Name == ("AutoPilot") || p.Name == ("FullSelfDriving")))
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?


        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });

       public ViewResult List7(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where((p => p.Name.StartsWith("Interior") || p.Name == ("Model S Standard")
        || p.Name == ("Paint") || p.Name == ("Rims")
        || p.Name == ("AutoPilot") || p.Name == ("FullSelfDriving")))
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?


        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });

       public ViewResult List8(string category, int page = 1)
        => View(new ProductsListViewModel
        {
            Products = repository.Products
        .Where((p => p.Name.StartsWith("Interior") || p.Name == ("Model S Plaid")
        || p.Name == ("Paint") || p.Name == ("Rims")
        || p.Name == ("AutoPilot") || p.Name == ("FullSelfDriving")))
        .OrderBy(p => p.ProductID)
       .Skip((page - 1) * PageSize)
        .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?


        repository.Products.Count() :
repository.Products.Where(e =>
        e.Category == category).Count()
            },
            CurrentCategory = category
        });


    }

 
}
