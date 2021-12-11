using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant.Repositories
{
    public class TenantContext : DbContext
    {

        public TenantContext(DbContextOptions<TenantContext> options) : base(options)
        {
        }
        public DbSet<TenantPersonnel> TenantPersonnel { get; set; }
        public DbSet<Gender> Gender { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
