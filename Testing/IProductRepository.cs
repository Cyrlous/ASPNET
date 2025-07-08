using System;
using System.Collections.Generic;
using Testing.Models;

namespace Testing;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
    
    Product GetProduct(int id);
}
