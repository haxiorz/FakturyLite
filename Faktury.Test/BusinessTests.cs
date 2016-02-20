using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faktury.WinForms;
using Faktury.Biz;
using System.Collections.Generic;

namespace Faktury.Test
{
    [TestClass]
    public class BusinessTests
    {
        [TestMethod]
        public void AddProduct()
        {
            //Arrange
            DBManager business = new DBManager();
            List<Product> products = new List<Product>();
            string expected = "1, Product, 23, 1, 100";

            //Act
            business.AddProduct(1, "Product", 23, 1, 100, true, products);
            string result = products[0].Id + ", " + products[0].Name + ", " + products[0].VAT + ", " + products[0].Quantity + ", " + products[0].NettoPrice;
            //Assert
            Assert.AreEqual(expected, result);

        }
    }
}
