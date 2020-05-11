using dataGatherer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataGatherer.Repository
{
    public class Context: IdentityDbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<SyncModelStore> SyncModels { get; set; }
        public Context(DbContextOptions<Context> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Model>().HasKey(t => t.ID);
        }
    }
}
