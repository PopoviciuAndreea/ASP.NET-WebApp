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
    public class DetailsModel : PageModel
    {
        private readonly PerfumeShopApp.Data.PerfumeShopAppContext _context;

        public DetailsModel(PerfumeShopApp.Data.PerfumeShopAppContext context)
        {
            _context = context;
        }

      public Order Order { get; set; }
        public IList<Order> OrderDetail { get; set; } = default!;

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
                OrderDetail = await _context.Order
                    .Include(b => b.Product)
                    .Include(b => b.User).ToListAsync();
            }
            return Page();
        }
    }
}
