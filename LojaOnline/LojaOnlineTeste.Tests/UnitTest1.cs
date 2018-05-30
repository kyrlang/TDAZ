using System;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Routing;
using LojaOnline.Context;
using LojaOnline.Controllers;
using LojaOnline.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LojaOnlineTeste.Tests
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void ViewHomeIndex()
        {
            HomeController home = new HomeController();
            ViewResult result = home.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
