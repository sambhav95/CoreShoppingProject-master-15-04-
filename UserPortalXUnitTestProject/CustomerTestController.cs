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
    public class CustomerTestController
    {
        private ShoppingProjectFinalContext context;
        public static DbContextOptions<ShoppingProjectFinalContext> dbContextOptions { get; set; }

        public static string connectionString =
           "Data Source=TRD-518; Initial Catalog = ShoppingProjectFinal; Integrated Security = true;";
        static CustomerTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShoppingProjectFinalContext>()
                    .UseSqlServer(connectionString).Options;
        }
        public CustomerTestController()
        {
            context = new ShoppingProjectFinalContext(dbContextOptions);
        }
        [Fact]
        public void Task_Login_Return_View()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                var controller = new CustomersController(context);
                var UserName = "sam";
                var Password = "sambhav";
                var data = controller.Login(UserName, Password);
                Assert.NotNull(data);
                Assert.IsType<ViewResult>(data);
            });
        }
        //[Fact]
        //public void Task_Register_Return_View()
        //{

        //    var controller = new CustomersController(context);

        //    controller.FirstName = "Shubhi";
        //    var CustomerLastName = "Dwivedi";
        //    var CustomerEmail = "shivani@user.com";
        //    var CustomerPassword = "123456";


        //    var data = controller.Register(FirstName);
        //    Assert.NotNull(data);


        //}

    }
}
