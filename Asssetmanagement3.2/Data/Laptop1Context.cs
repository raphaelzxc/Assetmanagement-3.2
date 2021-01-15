using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asssetmanagement3._2.Models;
using Asssetmanagement3._2.Helpers;
using System.Threading;

namespace Asssetmanagement3._2.Data
{
    public class Laptop1Context : DbContext
    {
        private ICurrentUserService currentUserService;
        public Laptop1Context (DbContextOptions<Laptop1Context> options,
            ICurrentUserService currentUserService)
            : base(options)
        {
            this.currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public DbSet<Asssetmanagement3._2.Models.Laptop> Laptop { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void ProcessSave()
        {
            var currentTime = DateTime.UtcNow;
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is Entity))
            {
                var entity = item.Entity as Entity;
                entity.CreatedDate = currentTime;
                entity.CreatedByUser = currentUserService.GetCurrentUsername();
                entity.ModifiedDate = currentTime;
                entity.ModifiedByUser = currentUserService.GetCurrentUsername();
            }
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified && e.Entity is Entity))
            {
                var entity = item.Entity as Entity;
                entity.ModifiedDate = currentTime;
                entity.ModifiedByUser = currentUserService.GetCurrentUsername();
                item.Property(nameof(entity.CreatedDate)).IsModified = false;
                item.Property(nameof(entity.CreatedByUser)).IsModified = false;
            }
        }
        public DbSet<Asssetmanagement3._2.Models.LaptopMinesite> MinesiteLaptop { get; set; }
    }
}
