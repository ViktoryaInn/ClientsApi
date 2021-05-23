using System;
using ClientsApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ClientsApi.Models
{
    public sealed class ApiContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<User> Users { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
            SavingChanges += OnSavingChangesSoft;
            SavingChanges += OnSavingChangesDates;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasQueryFilter(it => it.DeletedAt == null);
        }

        private void OnSavingChangesDates(object sender, SavingChangesEventArgs e)
        {
            if (!(sender is ApiContext context)) return;

            foreach (var entry in context.ChangeTracker.Entries())
            {
                if (!(entry.Entity is IEntity entity)) continue;
                
                var now = DateTime.UtcNow;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedAt = now;
                        entity.UpdatedAt = now;
                        break;

                    case EntityState.Modified:
                        entity.UpdatedAt = now;
                        break;
                }
            }
        }

        private void OnSavingChangesSoft(object sender, SavingChangesEventArgs e)
        {
            if (!(sender is ApiContext context)) return;

            var entries = context.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (!(entry.Entity is IEntity entity)) continue;

                var now = DateTime.UtcNow;
                if (entry.State != EntityState.Deleted) continue;
                switch (entity)
                {
                    case ISoftEntity softEntity:
                        entry.State = EntityState.Modified;
                        softEntity.DeletedAt = now;
                        entity.UpdatedAt = now;
                        break;
                }
            }
        }
    }
}