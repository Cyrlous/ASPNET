using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _repo;

    public ProductController(IProductRepository repo)
    {
        _repo = repo;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var products = await _repo.GetAllProducts();
        return View(products);
    }

    public async Task<IActionResult> ViewProduct(int id)
    {
        var product = await _repo.GetProduct(id);
        return View(product);
    }

    public async Task<IActionResult> UpdateProduct(int id)
    {
        Product product = await _repo.GetProduct(id);
        if (product == null)
        {
            return View("ProductNotFound");
        }
        return View(product);
    }

    public async Task<IActionResult> UpdateProductToDatabase(Product product)
    {
        await _repo.UpdateProduct(product);
        
        return RedirectToAction("ViewProduct", new {id = product.ProductID});
    }

    public async Task<IActionResult> InsertProduct(int id)
    {
        var prod = await _repo.AssignCategory();
        return View(prod);
    }

    public async Task<IActionResult> InsertProductToDatabase(Product product)
    {
        await _repo.InsertProduct(product);
        return RedirectToAction("Index");
    }
}