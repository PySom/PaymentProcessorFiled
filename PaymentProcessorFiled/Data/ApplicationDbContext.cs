using Microsoft.EntityFrameworkCore;
using PaymentProcessorFiled.Domains;

namespace PaymentProcessorFiled.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Define one to one relationship
            modelBuilder.Entity<Payment>()
                .HasOne(a => a.PaymentState)
                .WithOne(b => b.Payment);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentState> paymentStates { get; set; }

    }
}
