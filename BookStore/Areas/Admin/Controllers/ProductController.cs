using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productRepository.Add(product);
            _productRepository.Save();
            return RedirectToAction("Index", "Product");
        }


        public IActionResult Edit(int? id)
        {
            var product = _productRepository.Get(product => product.Id == id);
            var categories = _categoryRepository.GetAll()
                .Select(category => new SelectListItem(category.Name, Convert.ToString(category.Id)));
            ViewBag.Categories = categories;
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productRepository.Update(product);
            _productRepository.Save();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int? id)
        {
            var product = _productRepository.Get(product => product.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _productRepository.Delete(product);
            _productRepository.Save();
            return RedirectToAction("Index", "Product");
        }
    }
}
