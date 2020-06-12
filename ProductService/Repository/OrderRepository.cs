using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Model;
namespace ProductService.Repository
{
    public class OrderRepository
    {
        public Order GetById(Guid Id)

        {
            return new Order();
        }

        public Order AllOrder()

        {
            var Order = new Order();
            return Order;
        }
    }


}

