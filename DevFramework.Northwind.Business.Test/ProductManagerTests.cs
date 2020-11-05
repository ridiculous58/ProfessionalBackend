using System;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]//Beklenen bir hata oldugunu belli ettik yani bu methodun hata firlatmasi lazim firlatmaz ise test basarisiz olur
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDAL> mock = new Mock<IProductDAL>();//hayali bir instance olusturduk
            ProductManager productManager = new ProductManager(mock.Object);
            productManager.Add(new Product()); //Geçersiz bir model gonderdik
            //Success Test
        }
    }
}
