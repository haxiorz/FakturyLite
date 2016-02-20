using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faktury.Biz;

namespace Faktury.Test
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CalculateTotalNettoPrice()
        {
            // Arrange
            Product product = new Product(1, "Test product", 23, 2, 100, true);
            var expected = 200;

            // Act
            var actual = product.TotalNettoPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateVATValue()
        {
            // Arrange
            Product product = new Product(1, "Test product", 23, 1, 100, true);
            var expected = 23;

            // Act
            var actual = product.VATValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateBruttoPrice()
        {
            // Arrange
            Product product = new Product(1, "Test product", 23, 1, 100, true);
            var expected = 123;

            // Act
            var actual = product.BruttoPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateTotalBruttoPrice()
        {
            // Arrange
            Product product = new Product(1, "Test product", 23, 2, 100, true);
            var expected = 246;

            // Act
            var actual = product.TotalBruttoPrice;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
