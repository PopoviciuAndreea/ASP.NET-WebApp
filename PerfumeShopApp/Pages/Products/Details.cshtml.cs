using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumeShopApp.Data;
using PerfumeShopApp.Models;

namespace PerfumeShopApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly PerfumeShopApp.Data.PerfumeShopAppContext _context;

        public DetailsModel(PerfumeShopApp.Data.PerfumeShopAppContext context)
        {
            _context = context;
        }

      public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
    }
}
