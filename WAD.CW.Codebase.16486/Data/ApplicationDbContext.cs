using Microsoft.EntityFrameworkCore;

namespace WAD.CW.Codebase._16486.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurations (if needed)
            modelBuilder.Entity<Visitor>()
                .HasOne(v => v.Receptionist)
                .WithMany(r => r.Visitors)
                .HasForeignKey(v => v.ReceptionistId);
        }
    }

}
