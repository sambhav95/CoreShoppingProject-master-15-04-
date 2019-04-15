using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEcommerceUserPanal.Helpers;
using CoreShoppingAdminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreShoppingAdminPortal.Controllers
{     [Route("account")]
    public class AccountController : Controller
    {
        ShopDataDbContext context;
        public AccountController(ShopDataDbContext _context)
        {
            context = _context;
        }
        [Route("")]
        [RouteAttribute("index")]
        [Route("~/")]
         [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            Admin user = context.Admins.Where(a => a.AdminName == username).SingleOrDefault();
            ViewBag.admin = user;
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
            else
            {
                var userName = user.AdminName;
                int adminId = ViewBag.admin.AdminId;
                if (username != null && password != null && username.Equals(userName) && password.Equals(user.Password))
                {
                    HttpContext.Session.SetString("uname", username);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "admin", user);
                    HttpContext.Session.SetString("logout", userName);
                    return View("Home");
                    //"Account", new
                    //{
                    //    @id = adminId
                    //});
                }
                else
                {
                    ViewBag.Error = "Invalid credentials";
                    return View("Index");
                }
            }
        }
        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }
       
    }
}