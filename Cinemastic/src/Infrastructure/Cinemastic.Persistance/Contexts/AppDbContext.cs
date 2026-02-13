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

                        var result = entry.OriginalValues.GetValue<bool>(nameof(Movie.IsDeleted)) !=
                            entry.CurrentValues.GetValue<bool>(nameof(Movie.IsDeleted));

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
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieTag> MovieTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<TvShowCast> TvShowCasts { get; set; }
        public DbSet<TvShowCrew> TvShowCrews { get; set; }
        public DbSet<TvShowGenre> TvShowGenres { get; set; }
        public DbSet<TvShowTag> TvShowTags { get; set; }
        public DbSet<Slide> Slides { get; set; }

    }
}
