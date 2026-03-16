using Asp_net.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Asp_net.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
         new ProductViewModel()
         {
      Id = 1,
      Name = "Cheese",
      Price = 7.00
         },
         new ProductViewModel()
         {
       Id = 2,
       Name = "Ham",
       Price = 5.50
        },
         new ProductViewModel()
        {
       Id = 3,
       Name = "Bread",
       Price = 1.50
        }
        };
        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = this.products
                    .Where(pr => pr.Name.ToLower()
                    .Contains(keyword.ToLower()));

                return View(foundProducts);
            }

            return View(this.products);
        }
        public IActionResult Byid(int id)
        {
            var product = this.products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }
        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }
        public IActionResult AllAsText()
        {
            var result = string.Empty;

            foreach (var item in products)
            {
                result += $"Product {item.Id}: {item.Name} - {item.Price} lv";
                result += "\r\n";
            }

            return Content(result.ToString());
        }
    }
}