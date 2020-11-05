using System;
using System.Data.Entity;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.DataAccess.Test.EntityFramework
{
    [TestClass]
    public class EntityFrameworkTest
    {
        EfProductDAL productDAL = new EfProductDAL();

        [TestMethod]
        public void Get_all_returns_all_products()
        {
            var products = productDAL.GetList();
            Assert.AreEqual(77, products.Count);
        }
        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            var result = productDAL.GetList(x => x.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
