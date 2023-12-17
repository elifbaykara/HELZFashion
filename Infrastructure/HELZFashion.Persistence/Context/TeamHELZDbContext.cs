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
    public class TeamHELZDbContext : DbContext
    {

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Clothes> ClothesList { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public TeamHELZDbContext(DbContextOptions<TeamHELZDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}