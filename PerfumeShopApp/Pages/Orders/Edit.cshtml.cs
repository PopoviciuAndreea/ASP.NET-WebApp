using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerfumeShopApp.Data;
using PerfumeShopApp.Models;

namespace PerfumeShopApp.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly PerfumeShopApp.Data.PerfumeShopAppContext _context;

        public EditModel(PerfumeShopApp.Data.PerfumeShopAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order =  await _context.Order.FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            var productList = _context.Product
                .Select(x => new
                {
                    x.ID,
                    ProductNumeComplet = x.Brand + " - " + x.Nume
                });

            Order = order;
           ViewData["ProductID"] = new SelectList(productList, "ID", "ProductNumeComplet");
           ViewData["UserID"] = new SelectList(_context.User, "ID", "NumeComplet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
          return _context.Order.Any(e => e.ID == id);
        }
    }
}
