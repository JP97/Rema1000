using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rema1000.Models;

namespace Rema1000.Data
{
    public class Rema1000Context : DbContext
    {
        public Rema1000Context (DbContextOptions<Rema1000Context> options)
            : base(options)
        {
        }

        public DbSet<Rema1000.Models.Category> Category { get; set; }

        public DbSet<Rema1000.Models.Supplier> Supplier { get; set; }

        public DbSet<Rema1000.Models.Product> Products { get; set; }
    }
}
