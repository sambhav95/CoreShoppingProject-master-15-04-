using CoreEcommerceUserPanal.Controllers;
using CoreEcommerceUserPanal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UserPortalXUnitTestProject
{
    public class CartTestController
    {
        private ShoppingProjectFinalContext context;
        public static DbContextOptions<ShoppingProjectFinalContext> dbContextOptions { get; set; }

        public static string connectionString =
           "Data Source=TRD-518; Initial Catalog = ShoppingProjectFinal; Integrated Security = true;";
        static CartTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShoppingProjectFinalContext>()
                    .UseSqlServer(connectionString).Options;
        }
        public CartTestController()
        {
            context = new ShoppingProjectFinalContext(dbContextOptions);
        }
        [Fact]
        public void Task_Checkout_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {


                var controller = new CartController(context);
            //var CustomerId = 1;
            var customer = new Customers()
            {
                CustomerId = 1,
                FirstName = "Sambhav",
                LastName = "Jain",
                UserName = "sam",
              
                EmailId = "sa@gmail.com",
                Gender = "Male",
                Address = "Prashant",
                Country = "India",
               State = "Delhi",          
               
           
                
               Zip = 110085,
                PhoneNo = 9711861532,
                Password = "sambhav",
                ShippingAddress=true



            };
            var data = controller.Checkout(customer);
            Assert.IsType<RedirectResult>(data);
            });
        }
        [Fact]
        public void Task_remove_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var Id = 1;
                var data = controller.Remove(Id);
                Assert.IsType<ViewResult>(data);
            });
        }

        [Fact]
        public void Task_Status_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CartController(context);
                var data = controller.Invoice();
                Assert.IsType<ViewResult>(data);
            });
        }

    }
}
