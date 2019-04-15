using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreShoppingAdminPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreShoppingAdminPortal.Controllers
{
    public class FeedbackController : Controller
    {
        ShopDataDbContext context;
        public FeedbackController(ShopDataDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            var feed = context.Feedbacks.ToList();
            return View(feed);
        }
        public ViewResult Details(int id)
        {
            Feedback feed = context.Feedbacks.
             Where(x => x.FeedbackId == id).SingleOrDefault();
            return View(feed);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Feedback feed = context.Feedbacks.Where(x => x.FeedbackId == id).
                SingleOrDefault();
            return View(feed);
        }
        [HttpPost]
        public ActionResult Delete(int id, Feedback a1)
        {
            var feedback = context.Feedbacks.Where(x => x.FeedbackId == id).
                SingleOrDefault();
            context.Feedbacks.Remove(feedback);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}