using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Model;

namespace OrderService.Repository
{
    public interface IProductRepository
    {
        Product GetProById(Guid id);
        IEnumerable<Product> GetAll();
        Product DeleteById(Guid id);

    
       
    }
}
