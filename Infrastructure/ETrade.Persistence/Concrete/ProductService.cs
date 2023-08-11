﻿using ETrade.Application.Abstract;
using ETrade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Persistence.Concrete
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new() 
            {
            
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock = 10},
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock = 4},
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock = 10},
                new() { Id = Guid.NewGuid(), Name = "Product 4", Price = 400, Stock = 11},
                new() { Id = Guid.NewGuid(), Name = "Product 5", Price = 500, Stock = 12},
            
            };
        
    }
}
