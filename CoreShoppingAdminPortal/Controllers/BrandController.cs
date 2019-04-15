using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShoppingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreShoppingAdminPortal.Controllers
{
    public class BrandController : Controller
    {
        ShopDataDbContext context;
        public BrandController(ShopDataDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var brands = context.Brands.ToList();

            return View(brands);
        }
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Brand brand = context.Brands.Where(x => x.BrandId == id).SingleOrDefault();

            return View(brand);
        }
        [HttpPost]
        public ActionResult Edit(Brand brand, int id)
        {
            Brand brnd = context.Brands.Where(x => x.BrandId == id).SingleOrDefault();
            context.Entry(brnd).CurrentValues.SetValues(brnd);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            Brand brand = context.Brands.
               Where(x => x.BrandId == id).SingleOrDefault();
            return View(brand);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Brand brnd = context.Brands.Where(x => x.BrandId == id).
                SingleOrDefault();
            return View(brnd);
        }
        [HttpPost]
        public ActionResult Delete(int id, Brand b1)
        {
            Brand brnd = context.Brands.Where(x => x.BrandId == id).
                SingleOrDefault();
            context.Brands.Remove(brnd);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}