using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreEcommerceUserPanal.Models;
using Microsoft.AspNetCore.Http;
using CoreEcommerceUserPanal.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreEcommerceUserPanal.Controllers
{
    
    public class HomeController : Controller
    {
        //ShoppingProjectFinalContext context = new ShoppingProjectFinalContext();
        private readonly ShoppingProjectFinalContext _context;

        public HomeController(ShoppingProjectFinalContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var product = _context.Products.ToList();
            int j = 0;
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int i = 0;
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    i++;
                }
                if (i != 0)
                {
                    foreach (var i1 in cart)
                    {
                        j++;
                    }
                    HttpContext.Session.SetString("cartitem", j.ToString());
                }
            }
            return View(product);
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("user") && password.Equals("123456"))
            {
                HttpContext.Session.SetString("uname", username);
                return View("Home");
            }
            else
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
        }
        
        public IActionResult Display()
        {
            return View();
        }
       
        public IActionResult About()
        {
            return View();
        }
        //public IActionResult ChangePassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId<int>(), model.OldPassword, model.NewPassword);
        //    if (result.Succeeded)
        //    {
        //        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<int>());
        //        if (user != null)
        //        {
        //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //        }
        //        return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
        //    }
        //    AddErrors(result);
        //    return View(model);
        //}
        [HttpGet]
        public ViewResult Feedback()
        {
            ViewBag.Feed = new SelectList(_context.Customers, "CustomerId", "UserName");
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(Feedbacks fed)
        {
            _context.Feedbacks.Add(fed);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult HomePage()
        {
            return View();
        }
    }
}
