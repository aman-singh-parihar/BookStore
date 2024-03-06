using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookStoreDbContext _context;

        public CategoryController(BookStoreDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
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
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View(category);
            
        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        { 
            var category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var categoryToBeUpdated = _context.Categories.Where(x => x.Id == category.Id).FirstOrDefault();
            categoryToBeUpdated.Name = category.Name;
            categoryToBeUpdated.DisplayOrder = category.DisplayOrder;

            //_context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var category = _context.Categories.Find(id);
            return View(category);
        }
    }
}
