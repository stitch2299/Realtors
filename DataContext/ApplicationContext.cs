using Microsoft.EntityFrameworkCore;
using Realtors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Realtors.DataContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);

        public DbSet<SubDivision> SubDivisions { get; set; }

        public DbSet<Realtor> Realtors { get; set; }
    }
}
