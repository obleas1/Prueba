using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.DAL;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyAppDbContext _context; 

        public ProductController(MyAppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.Include("Categories");
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }
        [NonAction]
        private void LoadCategories()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                NotFound();
            }
            LoadCategories();
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if(!ModelState.IsValid)
            {
                _context.Products.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                NotFound();
            }
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Product model)
        {
            _context.Products.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
