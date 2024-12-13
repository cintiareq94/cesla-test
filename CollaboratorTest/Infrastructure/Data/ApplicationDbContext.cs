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


    }
}
