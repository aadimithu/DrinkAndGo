
using OrderService.Model;
using OrderService.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OrderService.test
{
    public class RepositoryTests
    {
       // public object Order { get; private set; }

        

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

