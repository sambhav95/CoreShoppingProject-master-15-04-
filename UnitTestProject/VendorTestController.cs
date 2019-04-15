//using CoreEcommerceUserPanal.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace UnitTestProject
//{
//   public class VendorTestController
//    {
//        private ShoppingProjectFinalContext context;
//        public static DbContextOptions<ShoppingProjectFinalContext> dbContextOptions { get; set; }

//        public static string connectionString =
//           "Data Source=TRD-518; Initial Catalog =ShoppingProjectFinal; Integrated Security = true;";
//        static VendorTestController()
//        {
//            dbContextOptions = new DbContextOptionsBuilder<ShoppingProjectFinalContext>()
//                    .UseSqlServer(connectionString).Options;
//        }
//        public VendorTestController()
//        {
//            context = new ShoppingProjectFinalContext(dbContextOptions);
//        }
//        [TestMethod]


//        public async void Task_GetVendorBy_Id_Return_OkResult()
//        {
//            var controller = new VendorTestController(context);
//            var VendorId = 1;
//            var data = await controller.Get(VendorId);
//            Assert.IsType<OkObjectResult>(data);
//        }
//        [TestMethod]
//        public async void Task_GetVendorBy_Id_Return_NoResult()
//        {
//            var controller = new VendorTestController(context);
//            var VendorId = 6;
//            var data = await controller.Get(VendorId);
//            Assert.IsType<NotFoundResult>(data);
//        }
//        [TestMethod]
//        public async void Task_GetVendorById_MatchResult()
//        {
//            var controller = new VendorController(context);
//            int id = 4;
//            var data = await controller.Get(id);
//            Assert.IsType<OkObjectResult>(data);
//            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
//            var vend = okResult.Value.Should().BeAssignableTo<Vendor>().Subject;
//            Assert.AreEqual("Sambhav", vend.VendorName);
//            Assert.AreEqual("sa@gmail.com", vend.EmailId);
//            Assert.AreEqual(9856324155, vend.PhoneNo);
//            Assert.AreEqual("Nice!!", vend.VendorDescription);

//        }
//        [TestMethod]
//        public async void Task_GetVendorById_BadResult()
//        {
//            var controller = new VendorController(context);
//            int? id = null;
//            var data = await controller.Get(id);
//            Assert.IsInstanceOfType<BadRequestResult>(data);

//        }
//        [TestMethod]
//        public async void Task_Add_AddVendor_Return_OkResult()
//        {
//            var controller = new VendorController(context);
//            var vend = new Vendor()
//            {
//                VendorName = "Naman ",
//                EmailId = "Naman@gmail.com",
//                PhoneNo = 9874525867,
//                VendorDescription = "Good"

//            };
//            var data = await controller.Post(vend);
//            Assert.IsInstanceOfType<CreatedAtActionResult>(data);

//        }
//    }
//}
