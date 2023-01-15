using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumeShopApp.Data;
using PerfumeShopApp.Models;

namespace PerfumeShopApp.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly PerfumeShopApp.Data.PerfumeShopAppContext _context;

        public DeleteModel(PerfumeShopApp.Data.PerfumeShopAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Order Order { get; set; }
        public IList<Order> OrderDelete { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.ID == id);

            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }

            if(_context.Order != null)
            {
                OrderDelete = await _context.Order
                    .Include(b => b.Product)
                    .Include(b => b.User).ToListAsync();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);

            if (order != null)
            {
                Order = order;
                _context.Order.Remove(Order);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
