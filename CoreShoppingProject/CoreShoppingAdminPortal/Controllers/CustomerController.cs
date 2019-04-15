using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShoppingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreShoppingAdminPortal.Controllers
{
    public class CustomerController : Controller
    {
        ShopDataDbContext context;
        public CustomerController(ShopDataDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}