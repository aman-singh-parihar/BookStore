using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductRepository productRepository
            ,ICategoryRepository categoryRepository
            ,IWebHostEnvironment environment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _environment = environment;
        }


        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            var categories = _categoryRepository.GetAll();

            var productViewModel = products.Select(product => new ListProductVM
            {
                Product = product,
                Category = new SelectListItem(categories.Where(category => category.Id == product.Category.Id).FirstOrDefault().Name,
                    categories.Where(category => category.Id == product.Category.Id).FirstOrDefault().Id.ToString(),
                    selected: true)

            }).ToList();
            return View(productViewModel);
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
            var vm = new ProductVM
            {
                Product = product,
                Categories = categories 
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductVM productViewModel, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(productViewModel);
            }
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_environment.WebRootPath,"images","products", fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }
            _productRepository.Update(productViewModel.Product);
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
