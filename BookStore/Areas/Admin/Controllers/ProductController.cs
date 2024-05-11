using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Create() 
        {
            ViewData["PageName"] = "Create";
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(Product product) 
        {
            if (!ModelState.IsValid) 
            {
                return View("Upsert", product);
            }
            _productRepository.Add(product);
            _productRepository.Save();
            return RedirectToAction("Index", "Product");
        }


        public IActionResult Edit(int? id) 
        {
            var product = _productRepository.Get(product => product.Id == id);
            ViewData["PageName"] = "Update";
            return View("Upsert", product);
        }

        public IActionResult Update(Product product) 
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productRepository.Update(product);
            _productRepository.Save();
            return RedirectToAction("Index", "Product");
        }
    }
}
