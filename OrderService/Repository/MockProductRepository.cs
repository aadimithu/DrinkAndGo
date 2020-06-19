using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Model;
using OrderService.Repository;


namespace OrderService.Repository
{
    
    public class MockProductRepository: IProductRepository
    {
        private List<Product> Products = new List<Product>();
        public MockProductRepository()
        {
            Product Product = new Product();
            Products = new List<Product>()
            {
                new Product
                {
                    Id =Guid.NewGuid(),
                    Name = "Beer can",
                    Description = "Beer can with 8.5% alchole ",
                    Price = 9.99M,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/1c/Beer_can.jpg"

                    },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Beer Bottle",
                    Description = "500ml bear bottle with 8.5% alchole",
                    Price = 20.99M,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c7/Kilimanjaro_Lager_beer.JPG"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Beer Mug",
                    Description = "500ml beer mug with 8.5% alchole",
                    Price = 8.99M,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/24/Kasztelan_beer_in_a_beer_mug%2C_Warsaw%2C_Poland.jpg"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Vodka",
                    Description = "7500ml vodka bottle with 40% alchole ",
                        
                    Price = 199.99M,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/15/Unflavored_Svedka_Vodka.jpg"
                },

                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Whisky",
                    Description = "7500 ml Whisky  with 40% alchole" ,
                      
                    Price = 199.99M,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/56/Whisky_bottles_2005.jpg"
                },

                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Energy Drink",
                    Description = "wold best energy drink. 330ml and alchole free",
                    Price = 30.99M,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9e/GOLD_Luxury_Energy_Drink.jpg"
                },

                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Cola Can",
                    Description = "Coca cola can, 330 ml and alchole free",
                    Price = 7.99M,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2f/Coca-cola_50cl_can_-_Italia.jpg"
                }
            };
           
            
        }

        public Product DeleteById(Guid id)
        {
            Product Product = new Product();
            try
            {
                Product = Products.Where(fp => fp.Id == id).FirstOrDefault();
                if (Product != null)
                {
                    Products.Remove(Product); 
                    
                }     
            }
            catch (Exception ex)
            {
                   throw ex;
            }
            return Product;
        }

        public IEnumerable<Product> GetAll()
        {
            return Products;
        }
                
        public Product GetProById(Guid id)
        {
            return Products.Where(f => f.Id == id).FirstOrDefault();
        }
    }
}
