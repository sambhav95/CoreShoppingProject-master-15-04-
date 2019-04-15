using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEcommerceUserPanal.Helpers;
using CoreEcommerceUserPanal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreEcommerceUserPanal.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        //ShoppingProjectFinalContext context = new ShoppingProjectFinalContext();
        private readonly ShoppingProjectFinalContext _context;

        public CartController(ShoppingProjectFinalContext context)
        {
            _context = context;
        }
        [Route("index")]
       
        public IActionResult Index()
        {

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
                    ViewBag.cart = cart;
                    ViewBag.total = cart.Sum(item => item.Products.ProductPrice * item.Quantity);
                    return View();
                }

            }
            return View("GoBack");
        }
        [Route("buy /{id}")]
        public IActionResult Buy(int id)
        {
            if(SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,"cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item
                {
                    Products = _context.Products.Find(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index !=-1)
                {
                    cart[index].Quantity++;
;                }
                else
                {
                    cart.Add(new Item
                    {
                        Products = _context.Products.Find(id),Quantity = 1 });
                    }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index","Home");

        }
        [Route("Remove/{id}")]
        
            public IActionResult Remove(int id)
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                int j = int.Parse(HttpContext.Session.GetString("cartitem"));
                int i = 0;
                foreach (var item in cart)
                {
                    i++;
                }
                if (i != 0)
                {
                    j--;
                    HttpContext.Session.SetString("cartitem", j.ToString());
                }
                else
                {
                    HttpContext.Session.Remove("cartitem");
                    return View("GoBack");
                }
                return RedirectToAction("Index");

            }
        [Route("GoBack")]
        public IActionResult GoBack()
        {
            return View();
        }

            private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>
                (HttpContext.Session, "cart");
            for(int i=0;i<cart.Count;i++)
            {
                if(cart[i].Products.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {

            var detail = _context.Products.Find(id);
            var cid = _context.Products.Find(id);
            ViewBag.cname = _context.Categories.Find(cid.ProductCategoryId);
            return View(detail);
        }
        public IActionResult Checkout()
        {
            int i = 0;
            ViewBag.i = i;
            var checkout = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,"cart");
            ViewBag.checkout = checkout;
            ViewBag.total = checkout.Sum(item => item.Products.ProductPrice * item.Quantity);
            string cust = HttpContext.Session.GetString("uname");
            Customers cus = _context.Customers.Where(x => x.UserName == cust).SingleOrDefault();
            ViewBag.cus = cus;
            ViewBag.totalitem = checkout.Count();
            TempData["total"] = ViewBag.total;
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Customers customer)
        {
            
         var c = _context.Customers.Where(x => x.UserName == customer.UserName).SingleOrDefault();
            c.FirstName = customer.FirstName;
            c.LastName = customer.LastName;
            c.UserName = customer.UserName;
            c.EmailId = customer.EmailId;
            c.Address = customer.Address;
            c.PhoneNo = customer.PhoneNo;
            c.Country = customer.Country;
            c.State = customer.State;
            c.Zip = customer.Zip;
            _context.SaveChanges();
                var amount = (TempData["total"]);
                Orders orders = new Orders()
                {
                    OrderPrice = Convert.ToSingle(amount),
                    OrderDate = DateTime.Now,
                    CustomerId = c.CustomerId

                };
                _context.Orders.Add(orders);
                _context.SaveChanges();
                var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                List<OrderProducts> OrderProducts = new List<OrderProducts>();

                for (int i = 0; i < cart.Count; i++)
                {
                    OrderProducts orderproducts = new OrderProducts()
                    {
                        OrderId = orders.OrderId,
                        ProductId = cart[i].Products.ProductId,
                        Quantity = cart[i].Quantity
                    };
                    OrderProducts.Add(orderproducts);
                }
                OrderProducts.ForEach(n => _context.OrderProducts.Add(n));
                _context.SaveChanges();
                TempData["cust"] = c.CustomerId;
                return RedirectToAction("Invoice");
            //}
            //return View();
        }
        [Route("Invoice")]
        public IActionResult Invoice()
        {
            int customerid = int.Parse(TempData["cust"].ToString());
            Customers customer = _context.Customers.Where(x => x.CustomerId == customerid).SingleOrDefault();
            ViewBag.Customers = customer;

            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            foreach(var Item in cart)
            {
                Products p = _context.Products.Find(Item.Products.ProductId);
                p.ProductQty = p.ProductQty - Item.Quantity;
                _context.SaveChanges();
            }
            ViewBag.total = cart.Sum(item => item.Products.ProductPrice * item.Quantity);
            cart = null;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            HttpContext.Session.Remove("cartitem");
            
                return View();
        }
        [Route("Plus")]
        [HttpGet]
        public IActionResult Plus(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                cart[index].Quantity++;
            }
            else
            {
                cart.Add(new Item
                {
                    Products = _context.Products.Find(id),
                    Quantity = 1
                });

            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        [Route("Minus")]
        [HttpGet]
        public IActionResult Minus(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            if (index != -1)
            {
                if (cart[index].Quantity != 1)
                {
                    cart[index].Quantity--;
                }

                else
                    return RedirectToAction("Remove", "Cart", new { @id = id });
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
       

    }
}
