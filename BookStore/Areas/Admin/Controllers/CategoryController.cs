using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        //[Authorize]
        public IActionResult Index()
        {
            var categories = _repository.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Category Name and Display Order should not be same");
            }
            if (ModelState.IsValid)
            {
                _repository.Add(category);
                _repository.Save();
                TempData["status"] = "Category created successfully.";
                return RedirectToAction("Index", "Category");
            }
            return View(category);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var category = _repository.Get(item => item.Id == id);
            return View(category);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult Update(Category category)
        {
            var categoryToBeUpdated = _repository.Get(item => item.Id == category.Id);
            categoryToBeUpdated.Name = category.Name;
            categoryToBeUpdated.DisplayOrder = category.DisplayOrder;

            //_context.Entry<Category>(category).State = EntityState.Modified;
            _repository.Save();
            TempData["status"] = "Category updated successfully.";
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _repository.Delete(category);
            _repository.Save();
            TempData["status"] = "Category deleted successfully.";
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var category = _repository.Get(item => item.Id == id);
            return View(category);
        }
    }
}
