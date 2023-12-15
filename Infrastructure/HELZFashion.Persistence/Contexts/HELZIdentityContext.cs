﻿using HELZFashion.Persistence.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Domain.Identity
{
    public class HELZIdentityContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<User> Users { get; set; }

        public HELZIdentityContext(DbContextOptions<HELZIdentityContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
