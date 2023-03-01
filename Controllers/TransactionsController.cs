using Controllers;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Gerenciador.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly Context _context;
        public TransactionsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult NewTransaction(int productId)
        {
            Transaction transaction = new Transaction {ProductId = productId};
            return View(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> NewTransaction(Transaction transaction)
        {
            transaction.DateTransaction = DateTime.Now.ToString();

            if(ModelState.IsValid)
            {
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction("DetailsProduct", "Produtos", new { productId = transaction.ProductId});
            }
            return View(transaction);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTransaction(int transactionId)
        {
            Transaction transaction = await _context.Transactions.FindAsync(transactionId);
            return View(transaction);
        }
        
        [HttpPost]
        public async Task<IActionResult> UpdateTransaction(Transaction transaction)
        {
            if(ModelState.IsValid)
            {
                _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction("DetailsProduct", "Products", new { productId = transaction.ProductId});
            }
            return View(transaction);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTransaction(int transactionId)
        {
            Transaction transaction = await _context.Transactions.FindAsync(transactionId);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction("DetailsProduct", "Product", new { productId = transaction.TransactionId});
        }
    }
}