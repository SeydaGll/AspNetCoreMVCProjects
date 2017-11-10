using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationEx.ViewModels;

namespace ValidationEx.Data
{
    public class ValidationExDbContext:DbContext
    {
        public ValidationExDbContext(DbContextOptions<ValidationExDbContext> options)
            :base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
