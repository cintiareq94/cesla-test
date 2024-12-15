using CollaboratorTest.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollaboratorTest.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Collaborator> Collaborator { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<CollaboratorCompanyLink> CollaboratorCompanyLink { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Collaborator>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Document).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Address).HasMaxLength(255);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TradeName).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Document).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(50);
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.IsEnabled);
            });

            modelBuilder.Entity<CollaboratorCompanyLink>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.CollaboratorId);
                entity.HasIndex(e => e.CompanyId);

                entity.Property(e => e.Role).HasMaxLength(100);
                entity.Property(e => e.Department).HasMaxLength(100);
                entity.Property(e => e.IsEnabled);

                entity.HasOne(e => e.Collaborator)
                      .WithMany(c => c.CollaboratorCompanyLinks)
                      .HasForeignKey(e => e.CollaboratorId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Company)
                      .WithMany(c => c.CollaboratorCompanyLinks)
                      .HasForeignKey(e => e.CompanyId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaborator>().HasData(
                new Collaborator { Id = 1, Name = "John Doe", Document = "1234567890", Phone = "555-1234", Email = "john.doe@example.com", Address = "123 Main St", CreationDate = new DateTime(2024, 04, 15) },
                new Collaborator { Id = 2, Name = "Jane Smith", Document = "9876543210", Phone = "555-5678", Email = "jane.smith@example.com", Address = "456 Elm St", CreationDate = new DateTime(2024, 05, 07) },
                new Collaborator { Id = 3, Name = "Alice Johnson", Document = "4561237890", Phone = "555-8765", Email = "alice.johnson@example.com", Address = "789 Oak St", CreationDate = new DateTime(2024, 03, 25) },
                new Collaborator { Id = 4, Name = "Bob Brown", Document = "7893216540", Phone = "555-4321", Email = "bob.brown@example.com", Address = "321 Pine St", CreationDate = new DateTime(2024, 06, 17) },
                new Collaborator { Id = 5, Name = "Eve Adams", Document = "6549871230", Phone = "555-9876", Email = "eve.adams@example.com", Address = "654 Maple St", CreationDate = new DateTime(2024, 01, 21) }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, TradeName = "TechCorp", Document = "TC12345", Phone = "555-1111", Address = "1 Innovation Way", IsEnabled = true },
                new Company { Id = 2, TradeName = "DesignCo", Document = "DC54321", Phone = "555-2222", Address = "2 Creative Ave", IsEnabled = true },
                new Company { Id = 3, TradeName = "FinancePlus", Document = "FP98765", Phone = "555-3333", Address = "3 Money Blvd", IsEnabled = true },
                new Company { Id = 4, TradeName = "MarketReach", Document = "MR67890", Phone = "555-4444", Address = "4 Branding St", IsEnabled = true },
                new Company { Id = 5, TradeName = "BuildMaster", Document = "BM13579", Phone = "555-5555", Address = "5 Construction Rd", IsEnabled = false }
            );

            modelBuilder.Entity<CollaboratorCompanyLink>().HasData(
                new CollaboratorCompanyLink { Id = 1, CollaboratorId = 1, CompanyId = 1, Role = "Manager", Department = "Sales", IsEnabled = true },
                new CollaboratorCompanyLink { Id = 2, CollaboratorId = 2, CompanyId = 2, Role = "Developer", Department = "IT", IsEnabled = true },
                new CollaboratorCompanyLink { Id = 3, CollaboratorId = 3, CompanyId = 3, Role = "Designer", Department = "Marketing", IsEnabled = true },
                new CollaboratorCompanyLink { Id = 4, CollaboratorId = 4, CompanyId = 4, Role = "Analyst", Department = "Finance", IsEnabled = true },
                new CollaboratorCompanyLink { Id = 5, CollaboratorId = 5, CompanyId = 5, Role = "Engineer", Department = "R&D", IsEnabled = false },
                new CollaboratorCompanyLink { Id = 6, CollaboratorId = 1, CompanyId = 2, Role = "Manager", Department = "Sales", IsEnabled = true },
                new CollaboratorCompanyLink { Id = 7, CollaboratorId = 2, CompanyId = 3, Role = "Developer", Department = "IT", IsEnabled = true },
                new CollaboratorCompanyLink { Id = 8, CollaboratorId = 3, CompanyId = 4, Role = "Designer", Department = "Marketing", IsEnabled = true },
                new CollaboratorCompanyLink { Id = 9, CollaboratorId = 4, CompanyId = 5, Role = "Analyst", Department = "Finance", IsEnabled = false },
                new CollaboratorCompanyLink { Id = 10, CollaboratorId = 5, CompanyId = 1, Role = "Engineer", Department = "R&D", IsEnabled = true }
            );
        }
    }
}