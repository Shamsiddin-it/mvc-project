using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using mvc.Data;

namespace mvc.Controllers
{
    public class ProductsController(ProductsRepo productsRepo) : Controller
    {
        private readonly ProductsRepo repo = productsRepo;
        // GET: ProductsController
        public ActionResult Index()
        {
            return View(repo.products);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            repo.Add(product);
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult GetById(int id)
        {
            var product = repo.GetById(id);
            return View(product);
        }
    }
}
