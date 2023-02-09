using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebNet6.Models;

namespace SalesWebNet6.Data
{
    public class SalesWebNet6Context : DbContext
    {
        public SalesWebNet6Context (DbContextOptions<SalesWebNet6Context> options)
            : base(options)
        {
        }

        public DbSet<SalesWebNet6.Models.Department> Department { get; set; } = default!;
    }
}
