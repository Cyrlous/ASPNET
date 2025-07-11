using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Testing.Models;

namespace Testing
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _conn.QueryAsync<Product>("SELECT * FROM products;");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _conn.QuerySingleAsync<Product>("SELECT * FROM products WHERE ProductID = @id;", new { id });
        }

        public async Task UpdateProduct(Product product)
        {
            await _conn.ExecuteAsync("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
                new {name = product.Name, price = product.Price, id = product.ProductID});
        }

        public async Task InsertProduct(Product product)
        {
            await _conn.ExecuteAsync("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new {name = product.Name, price = product.Price, categoryID = product.CategoryID});
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _conn.QueryAsync<Category>("SELECT * FROM categories;");
        }

        public async Task<Product> AssignCategory()
        {
            var categoryList = await GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }

        public async Task DeleteProduct(Product product)
        {
            await _conn.ExecuteAsync("DELETE FROM reviews WHERE ProductID = @id;", new { id = product.ProductID });
            await _conn.ExecuteAsync("DELETE FROM sales WHERE ProductID = @id;", new { id = product.ProductID });
            await _conn.ExecuteAsync("DELETE FROM products WHERE ProductID = @id;", new { id = product.ProductID });
        }
    }
}