using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEcommerceUserPanal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreEcommerceUserPanal.Controllers
{
    public class BrandController : Controller
    {
       // ShoppingProjectFinalContext context = new ShoppingProjectFinalContext();
        private readonly ShoppingProjectFinalContext _context;

        public BrandController(ShoppingProjectFinalContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            var brand = _context.Brands.ToList();
            return View(brand);
        }
       
        public async Task<IActionResult> ProductDisplay(int? id)
        {
            var p = _context.Products.Where(x => x.BrandId == id).ToList();
            return View(p);
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(int? id)

        {
            if (id == null)
            {
                return BadRequest();
            }
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null)

            {
                return NotFound();
            }
            return Ok(brand);
        }
    }
}