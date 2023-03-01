using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Controllers
{
    public class ProductsController : Controller
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Include(p => p.Category).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> NewProduct()
        {
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name");
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> DetailsProduct(int productId)
        {
            Product product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == productId);
            return View (product);
        }

        [HttpPost]
        public async Task<IActionResult>NewProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult>UpdateProduct(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);
            ViewData["CategoriaId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult>UpdateProduct(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirProduto(int productId)
        {
            Product product = await _context.Products.FindAsync(productId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}