using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.AppContext
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(p => p.OrderItem)
                .WithOne(p => p.Order)
                .HasForeignKey<OrderItem>(b => b.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(b => b.TransactionId);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.User)
                .WithMany(p => p.Orders);

            modelBuilder.Entity<PrintingEdition>()
                .HasOne(p => p.OrderItem)
                .WithMany(p => p.PrintingEditions);

            modelBuilder.Entity<AuthorInPrintingEdition>()
                .HasKey(t => new { t.AuthorId, t.PrintingEditionId });

            modelBuilder.Entity<AuthorInPrintingEdition>()
                .HasOne(p => p.PrintingEdition)
                .WithMany(p => p.AuthorInPrintingEditions)
                .HasForeignKey(pt => pt.PrintingEditionId);

            modelBuilder.Entity<AuthorInPrintingEdition>()
                .HasOne(p => p.Author)
                .WithMany(p => p.AuthorInPrintingEditions)
                .HasForeignKey(pt => pt.AuthorId);

            modelBuilder.Entity<UserInRole>()
                .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<UserInRole>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserInRoles)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserInRole>()
                .HasOne(p => p.Role)
                .WithMany(p => p.UserInRoles)
                .HasForeignKey(pt => pt.RoleId);
        }
    }
}
