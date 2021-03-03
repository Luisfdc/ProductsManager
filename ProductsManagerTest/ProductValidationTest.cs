using FluentValidation;
using ProductsManager.Entities;
using ProductsManager.Validations;
using System;
using Xunit;

namespace ProductsManagerTest
{
    public class ProductValidationTest
    {
        [Fact]
        public void Validate_Description_Null()
        {
            var product = new Product { Price = 1m, Image = "teste.jpg" };
            var result = product.IsValid();
            Assert.False(result);
        }

        [Fact]
        public void Validate_Price_Zero()
        {
            var product = new Product { Description = "Teste", Image = "teste.jpg" };
            var result = product.IsValid();
            Assert.False(result);
        }

        [Fact]
        public void Validate_Image_Null()
        {
            var product = new Product { Price = 1m, Description = "teste" };
            var result = product.IsValid();
            Assert.False(result);
        }

        [Fact]
        public void Validate_Product_Valid()
        {
            var product = new Product { Price = 1m, Image = "teste.jpg" };
            var result = product.IsValid();
            Assert.False(result);
        }
    }
}
