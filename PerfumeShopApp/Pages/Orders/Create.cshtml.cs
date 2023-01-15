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
    public class CreateModel : PageModel
    {
        private readonly PerfumeShopApp.Data.PerfumeShopAppContext _context;

        public CreateModel(PerfumeShopApp.Data.PerfumeShopAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var productList = _context.Product
                .Select(x => new
                {
                    x.ID,
                    ProductNumeComplet = x.Brand + " - " + x.Nume
                });

        ViewData["ProductID"] = new SelectList(productList, "ID", "ProductNumeComplet");
        ViewData["UserID"] = new SelectList(_context.User, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
