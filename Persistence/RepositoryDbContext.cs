using System.Reflection;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class RepositoryDbContext : IdentityDbContext
    {
        public RepositoryDbContext(DbContextOptions options)
            : base(options)
        {
        }

       

        public DbSet<Account> Accounts { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
