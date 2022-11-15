using Microsoft.AspNetCore.Mvc;
using Tuskla.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Tuskla.Controllers
{

    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        [Authorize]
        public ViewResult List() => View(repository.Orders.Where(o => !o.Shipped));

        public ViewResult List2(string OrderIdString = "")
        {
            if (!string.IsNullOrEmpty(OrderIdString))
            {
                int OrderIdInt = Int16.Parse(OrderIdString);
                /* If count = 0 need to fix to show all or send message */
                return View(repository.Orders.Where(o => o.OrderID == OrderIdInt));
            }

            else
            {
                return View(repository.Orders);
            }
        }

  
        public ViewResult List4(string OrderIdString = "", string OrderEmailString = "")
        {
            if (!string.IsNullOrEmpty(OrderIdString) & !string.IsNullOrEmpty(OrderEmailString))
            {
                int OrderIdInt = Int16.Parse(OrderIdString);
                /* If count = 0 need to fix to show all or send message */
                return View(repository.Orders.Where(o => o.OrderID == OrderIdInt
                & o.Email.ToLower() == (OrderEmailString.ToLower())));
            }

            else if (!string.IsNullOrEmpty(OrderEmailString))
            {
                return View(repository.Orders.Where(o => o.Email.ToLower() == (OrderEmailString.ToLower())));
            }

            else

            {
                return View(repository.Orders.Where(o => o.OrderID < 0));
            }

        }

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
            return RedirectToAction(nameof(List));
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

        public ViewResult CheckoutCar() => View(new Order());
        [HttpPost]
        public IActionResult CheckoutCar(Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                return RedirectToAction(nameof(CompletedCar));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            ViewBag.orderid = repository.Orders.Max(o => o.OrderID);
            return View();
        }

        public ViewResult CompletedCar()
        {
            cart.Clear();
            ViewBag.orderid = repository.Orders.Max(o => o.OrderID);
            return View();
        }
    }
}