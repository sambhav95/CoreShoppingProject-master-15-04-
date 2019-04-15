using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreShoppingAdminPortal.Controllers
{     [Route("account")]
    public class AccountController : Controller
    {
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
        {  if (username != null && password != null && username.Equals("admin") && password.Equals("123456"))
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
        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }
    }
}