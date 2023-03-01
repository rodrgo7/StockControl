using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ViewComponents
{
    public class TransactionsViewComponents : ViewComponent
    {
        private readonly Context _context;
        public TransactionsViewComponents(Context context)
        {
             _context = context;
        }
        public async Task<IViewComponentResult>InvokeAsync(int productId)
        {
            return View(await _context.Transactions.Where(m => m.ProductId == productId).ToListAsync());
        }
    }
}