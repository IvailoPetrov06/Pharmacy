using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;

namespace Pharmacy.Data
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext (DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }

        public DbSet<Pharmacy.Data.Medication> Medication { get; set; } = default!;

        public DbSet<Pharmacy.Data.Batch>? Batch { get; set; }

        public DbSet<Pharmacy.Data.Supplier>? Supplier { get; set; }

        public DbSet<Pharmacy.Data.Orders>? Orders { get; set; }
    }
}
