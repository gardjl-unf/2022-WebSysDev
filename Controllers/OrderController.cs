using Microsoft.AspNetCore.Mvc;
using Tuskla.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;
using Tuskla.Models.ViewModels;

namespace Tuskla.Controllers
{

    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repo, Cart cartService)

        {
            repository = repo;
            cart = cartService;
        }
        /*      public ViewResult List() => View(repository.Orders.Where(o => !o.Shipped));
        */
        [HttpGet]
        public IActionResult Find(string OrderIdString = "", string EmailString = "")
        {
            if (!string.IsNullOrEmpty(OrderIdString) && !string.IsNullOrEmpty(EmailString))
            {
                int OrderIdInt = Int16.Parse(OrderIdString);
                /* If count = 0 need to fix to show all or send message */
                return View(repository.Orders.Where(o => o.OrderID == OrderIdInt && o.Email.ToLower() == EmailString.ToLower()));
            }

            else if (!string.IsNullOrEmpty(EmailString))
            {
                return View(repository.Orders.Where(o => o.Email.ToLower() == EmailString.ToLower()));
            }

            else

            {

                return View(repository.Orders.Where(o => o.OrderID < 0));
            }
        }
        [Authorize]
        public ViewResult Manage(string OrderIdString = "", string EmailString = "")
        {
            if (!string.IsNullOrEmpty(OrderIdString) && !string.IsNullOrEmpty(EmailString))
            {
                int OrderIdInt = Int16.Parse(OrderIdString);
                /* If count = 0 need to fix to show all or send message */
                return View(repository.Orders.Where(o => o.OrderID == OrderIdInt && o.Email.ToLower() == EmailString.ToLower()));
            }

            else if (!string.IsNullOrEmpty(EmailString))
            {
                return View(repository.Orders.Where(o => o.Email.ToLower() == EmailString.ToLower()));
            }

            else if (!string.IsNullOrEmpty(OrderIdString))
            {
                int OrderIdInt = Int16.Parse(OrderIdString);
                return View(repository.Orders.Where(o => o.OrderID == OrderIdInt));
            }

            else

            {

                return View(repository.Orders.Where(o => o.OrderID > 0));
            }
        }
        [Authorize]
        public ViewResult ShipOrders() => View(repository.Orders.Where(o => !o.Shipped));
        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = repository.Orders
            .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(ShipOrders));
        }
        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {

            ViewBag.orderid = repository.Orders.Max(o => o.OrderID);
            
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = "/" });
        }

        public ViewResult CompletedCar()
        {
            cart.Clear();
            ViewBag.orderid = repository.Orders.Max(o => o.OrderID);
            return View();
        }
    }
}