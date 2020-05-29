
using ProductService.Model;
using ProductService.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProductService.test
{
    public class RepositoryTests
    {
        [Fact]
        public void GetProductbyId_Returns_Product()
        {
            var productsRepository = new ProductRepository();

            var product = productsRepository.GetById(Guid.Empty);

            // Assert.IsType<Product>( product);
            Assert.Equal(Guid.Empty, product.Id);
        }

        [Fact]
        public void GetAllProduct_Returns_ListOfProduct()
        {
            var productsRepository = new ProductRepository();
            var products = productsRepository.AllProduct();
            Assert.IsType<Product>(products);
        }
    }
}
