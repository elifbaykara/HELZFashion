using HELZFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace HELZFashion.Persistence.Context
{
    public class HELZFashionDbContext : DbContext
    {
       public DbSet<Category> Categories { get; set; }
        public HELZFashionDbContext(DbContextOptions<HELZFashionDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public HELZFashionDbContext()
        {
        }
    }
}
