
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
        public object Order { get; private set; }

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


        [Fact]
        public void GetOrderbyId_Returns_Order()
        {
          var OrdersRepository = new OrderRepository();

        var Order = OrdersRepository.GetById(Guid.Empty);


       Assert.Equal(Guid.Empty, Order.Id);
         }


        [Fact]
        public void GetAllOrder_Returns_ListOfOrder()
        {
            var ordersRepository = new OrderRepository();
            var orders = ordersRepository.AllOrder();
            Assert.IsType<Order>(orders);
        }

    }



}
