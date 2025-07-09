using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();
    
    Task<Product> GetProduct(int id);
    
    Task UpdateProduct(Product product);
}
