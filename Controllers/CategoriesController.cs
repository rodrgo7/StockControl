using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Context _context;
        public CategoriesController(Context context)
        {
            _context = context;
        }   
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }
        [HttpGet]
        public IActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>NewCategory (Category category)
        {
            if (ModelState.IsValid)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));                
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IAsyncResult>UpdateCategory(int categoryId)
        {
            return (IAsyncResult)View(await _context.Categories.FindAsync(categoryId));
        }
        [HttpPost]
        public async Task<IActionResult>UpdateCategory(Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            Category category = await _context.Categories.FindAsync(categoryId);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}