using Cinemastic.Domain.Entities;
using Cinemastic.Persistance.Context.common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Context
{
    internal class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyAllQueryFilters();

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _setDateTime();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void _setDateTime()
        {
            var datas = ChangeTracker.Entries<BaseAccountableEntity>();
            foreach (var entry in datas)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        //var  result=entry.Property(nameof(Category.IsDeleted)).IsModified;

                        var result = entry.OriginalValues.GetValue<bool>(nameof(Content.IsDeleted)) !=
                            entry.CurrentValues.GetValue<bool>(nameof(Content.IsDeleted));

                        if (!result)
                        {
                            entry.Entity.Updated = DateTime.UtcNow;

                        }
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentCast> ContentCasts { get; set; }
        public DbSet<ContentCrew> ContentCrews { get; set; }
        public DbSet<ContentGenre> ContentGenres { get; set; }
        public DbSet<ContentTag> ContentTags { get; set; }
        public DbSet<Tag> Tags { get; set; }


    }
}
