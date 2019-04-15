using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShoppingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreShoppingAdminPortal.Controllers
{
    public class VendorController : Controller
    {
        ShopDataDbContext context;
        public VendorController(ShopDataDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var vendors = context.vendors.ToList();

            return View(vendors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vendor vendor)
        {
            context.vendors.Add(vendor);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vendor vend = context.vendors.Where(x => x.VendorId == id).SingleOrDefault();
            ViewBag.authors = new SelectList(context.vendors, "VendorId", "Title");
            return View(vend);
        }
        [HttpPost]
        public ActionResult Edit(Vendor v1)
        {
            Vendor vend = context.vendors.Where(x => x.VendorId == v1.VendorId).SingleOrDefault();

            context.Entry(vend).CurrentValues.SetValues(v1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}