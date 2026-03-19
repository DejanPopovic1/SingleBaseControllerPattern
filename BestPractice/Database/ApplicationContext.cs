using Microsoft.EntityFrameworkCore;
using BestPractice.Utilities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            var test = entries.First().GetDatabaseValues().GetValue<string>("test1");
            
            return 1;

        }


        public override int SaveChanges()
        {

            IEnumerable<EntityEntry> entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            var firstEntry = entries.First();
            //This wont work for additions
            //var propertyValue = entries.First().GetDatabaseValues().GetValue<string>("test1");
            var propertyName = firstEntry.Properties.First().Metadata.Name;
            //Original value = current value for add
            var originalValue = firstEntry.Properties.ElementAt(1).OriginalValue;
            var currentValue = firstEntry.Properties.ElementAt(1).CurrentValue;
            return base.SaveChanges();
        }
    }
}
