using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project0DbContext
{
    public partial class Project0DBContext : DbContext
    {
        public Project0DBContext()
        {
        }

        public Project0DBContext(DbContextOptions<Project0DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Project0DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.StoreId, "IX_Customers_StoreId");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Customers__Store__3B75D760");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("PK__Inventor__F0C23D6D18EEEB0F");

                entity.HasIndex(e => e.ProductId, "IX_Inventories_ProductId");

                entity.HasIndex(e => e.StoreId, "IX_Inventories_StoreId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventori__Produ__45F365D3");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventori__Store__44FF419A");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.StoreId, "IX_Orders_StoreId");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__StoreId__4222D4EF");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.OrderId })
                    .HasName("PK__OrderHis__48976164C1F224D8");

                entity.ToTable("OrderHistory");

                entity.HasIndex(e => e.OrderId, "IX_OrderHistory_OrderId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderHist__Custo__47DBAE45");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderHistories)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderHist__Order__48CFD27E");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.LineId)
                    .HasName("PK__OrderLin__2EAE65294175844C");

                entity.HasIndex(e => e.OrderId, "IX_OrderLines_OrderId");

                entity.HasIndex(e => e.ProductId, "IX_OrderLines_ProductId");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__Order__5AEE82B9");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderLine__Produ__3E52440B");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductDescr).HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreLocation)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
