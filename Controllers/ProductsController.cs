using Asp_net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Asp_net.Controllers
{
    public class ProductsController : Controller
    {
        private static List<ProductViewModel> products = new()
        {
            new ProductViewModel { Id = 1, Name = "Bread", Price = 2.40m },
            new ProductViewModel { Id = 2, Name = "Milk", Price = 3.10m },
            new ProductViewModel { Id = 3, Name = "Cheese", Price = 5.80m }
        };

        public IActionResult All()
        {
            return View(products);
        }

        public IActionResult ById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult AllAsText()
        {
            var result = string.Empty;

            foreach (var item in products)
            {
                result += $"Product {item.Id}: {item.Name} - {item.Price} lv";
                result += "\r\n";
            }

            return Content(result);
        }
    }
}