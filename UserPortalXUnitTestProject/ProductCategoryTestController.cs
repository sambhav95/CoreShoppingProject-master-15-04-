using CoreEcommerceUserPanal.Controllers;
using CoreEcommerceUserPanal.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace UserPortalXUnitTestProject
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
        [Fact]
        public async void Task_GetProductCategoryBy_Id_Return_OkResult()
        {
            var controller = new ProductCategoryController(context);
            var ProductCategoryId = 1;
            var data = await controller.Get(ProductCategoryId);
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_GetProductCategoryBy_Id_Return_NoResult()
        {
            var controller = new ProductCategoryController(context);
            var ProductCategoryId = 6;
            var data = await controller.Get(ProductCategoryId);
            Assert.IsType<NotFoundResult>(data);
        }
        [Fact]
        public async void Task_GetProductCategoryById_MatchResult()
        {
            var controller = new ProductCategoryController(context);
            int id = 1;
            var data = await controller.Get(id);
            Assert.IsType<OkObjectResult>(data);
            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var prod = okResult.Value.Should().BeAssignableTo<Categories>().Subject;
            Assert.Equal("Summer Collection", prod.CategoryName);
            Assert.Equal("Cotton", prod.CategoryDescription);

        }
        [Fact]
        public async void Task_GetProductCategoryById_BadResult()
        {
            var controller = new ProductCategoryController(context);
            int? id = null;
            var data = await controller.Get(id);
            Assert.IsType<BadRequestResult>(data);

        }

    }
}

