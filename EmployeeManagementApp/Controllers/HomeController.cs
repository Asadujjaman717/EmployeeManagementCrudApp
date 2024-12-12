using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EmployeeManagementApp.Services;

namespace EmployeeManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(); // Ensure there's a corresponding Index.cshtml in Views/Home
        }
        public async Task<IActionResult> ProductList()
        {
            var products = await _productService.GetProductListAsync();
            return View(products);
        }
    }
}



