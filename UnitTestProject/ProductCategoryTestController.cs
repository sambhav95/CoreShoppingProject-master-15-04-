using CoreEcommerceUserPanal.Controllers;
using CoreEcommerceUserPanal.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
   public class ProductCategoryTestController
    {
        private ShoppingProjectFinalContext context;
        public static DbContextOptions<ShoppingProjectFinalContext> dbContextOptions { get; set; }

        public static string connectionString =
           "Data Source=TRD-518; Initial Catalog = ShoppingProjectFinal; Integrated Security = true;";
        static ProductCategoryTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ShoppingProjectFinalContext>()
                    .UseSqlServer(connectionString).Options;
        }
        public ProductCategoryTestController()
        {
            context = new ShoppingProjectFinalContext(dbContextOptions);
        }
        [TestMethod]
             public async void Task_GetProductCategoryBy_Id_Return_OkResult()
        {
            var controller = new ProductCategoryController(context);
            var ProductCategoryId = 1;
            var data = await controller.ProductDisplay(ProductCategoryId);
            Assert.IsInstanceOfType<RedirectResult>(data);
        }
        [TestMethod]
        public async void Task_GetProductCategoryBy_Id_Return_NoResult()
        {
            var controller = new ProductCategoryController(context);
            var ProductCategoryId = 6;
            var data = await controller.ProductDisplay(ProductCategoryId);
            Assert.IsType<NotFoundResult>(data);
        }
        [TestMethod]
        public async void Task_GetProductCategoryById_MatchResult()
        {
            var controller = new ProductCategoryController(context);
            int id = 1;
            var data = await controller.ProductDisplay(id);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var prod = okResult.Value.Should().BeAssignableTo<Categories>().Subject;
            Assert.Equals("Autmn Collection", prod.CategoryName);
            Assert.Equals("Floral Collection", prod.CategoryDescription);

        }
        [TestMethod]
        public async void Task_GetProductCategoryById_BadResult()
        {
            var controller = new ProductCategoryController(context);
            int? id = null;
            var data = await controller.ProductDisplay(id);
            Assert.IsInstanceofType<BadRequestResult>(data);

        }

    }
}
