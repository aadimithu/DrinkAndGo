using ProductService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Repository
{
    public class ProductRepository
    {
        public Product GetById(Guid Id)

        {
            return new Product();
        }

        public Product AllProduct()

        {
            var products = new Product();
            return  products;
        }
    }

}
