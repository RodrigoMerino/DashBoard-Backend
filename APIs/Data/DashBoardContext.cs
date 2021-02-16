using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIs.Data
{
    public partial class DashBoardContext : DbContext
    {
        public DashBoardContext()
        {
        }

        public DashBoardContext(DbContextOptions<DashBoardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Server> Server{ get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(builder =>
            {;
                builder.Property(e => e.CustomerId);

                builder.Property(e => e.Email).HasMaxLength(50);

                builder.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength();

                builder.Property(e => e.State)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.Property(e => e.OrderId);

                builder.Property(e => e.Completed).HasColumnType("datetime");

                builder.Property(e => e.Placed).HasColumnType("datetime");

                builder.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                builder.HasOne(d => d.CustomerIdNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<Server>(builder =>
            {
                builder.Property(e => e.Name).HasMaxLength(50);
                builder.Property(e => e.IsOnline);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
