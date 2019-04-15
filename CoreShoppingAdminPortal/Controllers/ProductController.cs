using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShoppingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreShoppingAdminPortal.Controllers
{
    public class ProductController : Controller
    {
        ShopDataDbContext context;
        public ProductController(ShopDataDbContext _context)
        {
            context = _context;
        }
        public ViewResult Index()
        {
            var pc = context.Products.ToList();
            return View(pc);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.products = new SelectList(context.Vendors, "VendorId", "VendorName");
            ViewBag.products1 = new SelectList(context.Categories, "ProductCategoryId", "CategoryName");
            ViewBag.product2 = new SelectList(context.Brands, "BrandId", "BrandName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ViewResult Details(int id)
        {
            Product product = context.Products.
                   Where(x => x.ProductId == id).SingleOrDefault();
            return View(product);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var pc = context.Products.Where(x => x.ProductId == id).SingleOrDefault();
            return View(pc);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product d1)
        {
            var pc = context.Products.Where(x => x.ProductId == id).SingleOrDefault();
            context.Products.Remove(pc);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pc = context.Products.Where(x => x.ProductId == id).SingleOrDefault();
            ViewBag.Categories =
            new SelectList(context.Categories, "ProductCategoryId", "CategoryName",pc.ProductCategoryId);
            ViewBag.Vendor =
            new SelectList(context.Vendors, "VendorId", "VendorName",pc.VendorId);
            ViewBag.Brand =
                 new SelectList(context.Brands, "BrandId", "BrandName", pc.BrandId);
            return View(pc);
        }
        [HttpPost]
        public ActionResult Edit(Product product, int id)
        {
            var pc = context.Products.Where(x => x.ProductId == product.ProductId).SingleOrDefault();

            //prod.ProductCategoryId = productcategory.ProductCategoryId;
            //prod.CategoryName = productcategory.CategoryName;
            //prod.CategoryDescription = productcategory.CategoryDescription;
            context.Entry(pc).CurrentValues.SetValues(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}