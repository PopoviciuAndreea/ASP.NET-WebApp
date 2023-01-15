using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumeShopApp.Models;

namespace PerfumeShopApp.Data
{
    public class PerfumeShopAppContext : DbContext
    {
        public PerfumeShopAppContext (DbContextOptions<PerfumeShopAppContext> options)
            : base(options)
        {
        }

        public DbSet<PerfumeShopApp.Models.Product> Product { get; set; } = default!;

        public DbSet<PerfumeShopApp.Models.User> User { get; set; }

        public DbSet<PerfumeShopApp.Models.Order> Order { get; set; }
    }
}
