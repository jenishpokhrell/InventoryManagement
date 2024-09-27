using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDBContext dbContext;
        public ProductsController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            var product = new Product
            {
                ProductName = viewModel.ProductName,
                Description = viewModel.Description,
                Location = viewModel.Location,
                Quantity = viewModel.Quantity,
                Price = viewModel.Price,
            };
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var students = await dbContext.Products.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(Guid id)
        {
            var student = await dbContext.Products.FindAsync(id);
            return View(student);
        }
    }
}
