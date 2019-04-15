using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShoppingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreShoppingAdminPortal.Controllers
{
    public class ProductCategoryController : Controller
    {
        ShopDataDbContext context;
        public ProductCategoryController(ShopDataDbContext _context)
        {
            context = _context;
        }
        public ViewResult Index()
        {
            var pc = context.Categories.ToList();
            return View(pc);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCategory productcategory)
        {
            context.Categories.Add(productcategory);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ViewResult Details(int id)
        {
            ProductCategory category = context.Categories.
                   Where(x => x.ProductCategoryId == id).SingleOrDefault();
            return View(category);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var pc = context.Categories.Where(x => x.ProductCategoryId == id).SingleOrDefault();
            return View(pc);
        }
        [HttpPost]
        public ActionResult Delete(int id, ProductCategory d1)
        {
            var pc = context.Categories.Where(x => x.ProductCategoryId == id).SingleOrDefault();
            context.Categories.Remove(pc);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
              var pc = context.Categories.Where(x => x.ProductCategoryId == id).SingleOrDefault();
            //ViewBag.Categories =
            //    new SelectList(context.Categories, "CategoryId", "CategoryName", pc.ProductCategoryId);
            return View(pc);
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productcategory,int id)
        {
            var pc = context.Categories.Where(x => x.ProductCategoryId == id).SingleOrDefault();

            //prod.ProductCategoryId = productcategory.ProductCategoryId;
            //prod.CategoryName = productcategory.CategoryName;
            //prod.CategoryDescription = productcategory.CategoryDescription;
            context.Entry(pc).CurrentValues.SetValues(productcategory);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}