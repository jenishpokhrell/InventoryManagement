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
            var products = await dbContext.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product viewModel)
        {
            var product = await dbContext.Products.FindAsync(viewModel.Id);
            if(product is not null)
            {
                product.ProductName = viewModel.ProductName;
                product.Description = viewModel.Description;
                product.Location = viewModel.Location;
                product.Quantity = viewModel.Quantity;
                product.Price = viewModel.Price;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("ProductList", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product viewModel)
        {
            var product = await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if(product is not null)
            {
                dbContext.Products.Remove(viewModel);
                await dbContext.SaveChangesAsync(true);
            }
            return RedirectToAction("ProductList", "Products");
        }
    }
}
