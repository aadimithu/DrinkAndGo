using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drinko.Models;

namespace Drinko.Repository
{
    public interface IProductRepository
    {
        Product GetFoodProById(Guid id);
        IEnumerable<Product> GetAll();
        Product DeleteById(Guid id);

    
       
    }
}
