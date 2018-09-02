using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.API.Controllers;
using HelloWorld.API.Models;
using System.Linq;

namespace HelloWorld.API.Tests.Controllers
{
    /// <summary>
    /// Summary description for HWControllerTest
    /// </summary>
    [TestClass]
    public class HWControllerTest
    {
        private HWController controller;
        public HWControllerTest()
        {
            controller = new HWController();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void GetAll()
        {

            List<HWModel> result = controller.GetMessages().ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            
        }

        [TestMethod]
        public void GetSingle()
        { 

            //Act
            var result = controller.GetMessage(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Hello World!", result.Message);
        }

        [TestMethod]
        public void Post()
        {

            controller.PostMessage(new HWModel() { ID = 3, Message = "PostTest" });

            var result = controller.GetMessages().ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("PostTest", result[2].Message);
        }
        [TestMethod]
        public void Delete()
        {
            controller.DeleteMessage(2);
        }
    }
}
