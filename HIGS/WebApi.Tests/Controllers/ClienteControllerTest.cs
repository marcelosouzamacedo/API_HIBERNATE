using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi;
using WebApi.Controllers;
using Model.Model;

namespace WebApi.Tests.Controllers
{
    [TestClass]
    public class ClienteControllerTest
    {
        [TestMethod]
        public void GetById()
        {
            // Arrange
            ClienteController controller = new ClienteController();

            // Act
            Cliente result = controller.GetCliente(0);

            // Assert
            Assert.IsNull(result);
        }
    }
}
