using Microsoft.EntityFrameworkCore;
using WebApplication3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Contexts
{
    public class ApplicationDbContext:  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Autores> Autores { get; set; }
    }
}
