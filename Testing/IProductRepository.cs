using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProducts();
    
    public Task<Product> GetProduct(int id);
    
    public Task UpdateProduct(Product product);
    
     public Task InsertProduct(Product product);
     public Task<IEnumerable<Category>> GetCategories();
     public Task<Product> AssignCategory();
     public Task DeleteProduct(Product product);
}
