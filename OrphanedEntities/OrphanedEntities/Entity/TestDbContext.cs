using Microsoft.EntityFrameworkCore;
using OrphanedEntities.Dal;

namespace OrphanedEntities.Entity
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        // Registered DB Model in OurHeroDbContext file
        public DbSet<CompanyEntity> Companies { get; set; }

        /*
         OnModelCreating mainly used to configured our EF model
         And insert master data if required
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyEntity>().ToTable("Company").HasKey(x => x.Id);
            modelBuilder.Entity<CompanyPropertyEntity>().ToTable("CompanyProperty").HasKey(x => x.Id);

            modelBuilder.Entity<CompanyPropertyEntity>()
                .HasOne(c => c.CompanyEntity)
                .WithMany(c => c.CompanyProperties)
                .HasForeignKey(c => c.CompanyId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

    
            modelBuilder.Entity<CompanyEntity>().HasData(
                new CompanyEntity
                {
                    Id = 1,
                    Name = "CompanyEntity 1"}

            );

            modelBuilder.Entity<CompanyPropertyEntity>().HasData(
                new CompanyPropertyEntity
                {
                    Id = 1,
                    CompanyId = 1,
                    Name = "Prop 1"
                });

            modelBuilder.Entity<CompanyPropertyEntity>().HasData(
                new CompanyPropertyEntity
                {
                    Id = 2,
                    CompanyId = 1,
                    Name = "Prop 2"
                });
        }
    }
}

