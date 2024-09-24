using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel viewModel)
        {
            return View();
        }
    }
}
