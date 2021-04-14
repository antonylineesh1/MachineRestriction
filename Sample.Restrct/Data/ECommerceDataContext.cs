using Microsoft.EntityFrameworkCore;
using Sample.Restrct.Data.Entities;
using Sample.Restrct.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Restrct.Data
{
    public class ECommerceDataContext:DbContext
    {
        
        public ECommerceDataContext(DbContextOptions<ECommerceDataContext> options):base(options)
        {}
        public DbSet<User> Users { get; set; }
        public DbSet<UserMachine>  UserMachines { get; set; }
        public DbSet<UsemachineInfoResultSet> UsemachineInfoResultSet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
