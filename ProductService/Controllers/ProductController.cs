using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Repository;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;

namespace ProductService.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController()
        {
            _productRepository = new MockProductRepository();
        }
        [HttpGet]
        public IList<Product> Get()
        {
            return _productRepository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Product GetById(Guid id)
        {
            return _productRepository.GetProById(id);
        }
    }
}