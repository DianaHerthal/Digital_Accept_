using Digital_Accept.Data.Mapping;
using Digital_Accept.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Digital_Accept.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opcoes)
            : base(opcoes)
        {

        }

        public ApplicationDbContext()
        {

        }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Signature> Signatures { get; set; }

        public DbSet<Signatary> Sigantaries { get; set; }

        public DbSet<SignataryDocument> SignatariesDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Document>(new DocumentConfiguration().Configure);
            modelBuilder.Entity<Event>(new EventConfiguration().Configure);
            modelBuilder.Entity<Signature>(new SignatureConfiguration().Configure);
            modelBuilder.Entity<Signatary>(new SignataryConfiguration().Configure);
            modelBuilder.Entity<SignataryDocument>(new SignataryDocumentConfiguration().Configure);
        }
    }
}
