using Microsoft.EntityFrameworkCore;
using BestPractice.Utilities;

namespace BestPractice.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ExtendedComponent> ExtendedComponents { get; set; }

        public DbSet<Extended2Component> Extended2Components { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected async override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Actor>()
                .Property(p => p.AdditionalInformation)
                .HasConversion(new JsonDocumentConverter());
        }
    }
}
