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
