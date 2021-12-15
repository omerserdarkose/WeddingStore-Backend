using System;
using HelenSposa.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HelenSposa.DataAccess.Concrete.EntityFramework
{
    //Scaffold-DbContext "Server=DRMORAREES\SQLEXPRESS;Database=HelenSposaDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Concrete/ -force
    public partial class HelenSposaDbContext : DbContext
    {
        public HelenSposaDbContext()
        {
        }

        public HelenSposaDbContext(DbContextOptions<HelenSposaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BasketDetail> BasketDetails { get; set; }
        public virtual DbSet<BasketsEvent> BasketsEvents { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpensesType> ExpensesTypes { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DRMORAREES\\SQLEXPRESS;Database=HelenSposaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasIndex(e => e.DateOfSale, "IX_Baskets_DateOfSale")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.IsDone, "IX_Baskets_IsDone")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.DateOfSale).HasColumnType("datetime");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Baskets_Customers");
            });

            modelBuilder.Entity<BasketDetail>(entity =>
            {
                entity.HasIndex(e => e.SaleType, "IX_BasketDetails_SaleType")
                    .HasFillFactor((byte)10);

                entity.HasIndex(e => new { e.BasketId, e.ProductId }, "UK_BasketDetails_BasketId_ProductId")
                    .IsUnique();

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketDetails)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketDetails_Baskets");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.BasketDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketDetails_Products");
            });

            modelBuilder.Entity<BasketsEvent>(entity =>
            {
                entity.HasIndex(e => e.BasketId, "IX_BasketsEvents_BasketId")
                    .HasFillFactor((byte)10);

                entity.HasIndex(e => e.EventId, "UK_BasketsEvents_EventId")
                    .IsUnique();

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketsEvents)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketsEvents_Baskets");

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.BasketsEvent)
                    .HasForeignKey<BasketsEvent>(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasketsEvents_Events");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UK_Customers_Phone")
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired();

                entity.Property(e => e.IsDeleted)
                    .IsRequired();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Events_CustomerId")
                    .HasFillFactor((byte)10);

                entity.HasIndex(e => e.Date, "IX_Events_Date")
                    .HasFillFactor((byte)10);

                entity.HasIndex(e => e.IsDone, "IX_Events_IsDone")
                    .HasFillFactor((byte)10);

                entity.HasIndex(e => e.TypeId, "IX_Events_TypeId")
                    .HasFillFactor((byte)10);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.No)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Customers");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_EventTypes");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasIndex(e => e.Name, "UK_EventTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasIndex(e => e.Date, "IX_Expenses_Date")
                    .HasFillFactor((byte)10);

                entity.HasIndex(e => e.TypeId, "IX_Expenses_TypeId")
                    .HasFillFactor((byte)10);

                entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expenses_ExpensesTypes");
            });

            modelBuilder.Entity<ExpensesType>(entity =>
            {
                entity.HasIndex(e => e.Name, "UK_ExpensesTypes_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasIndex(e => e.BasketId, "IX_Incomes_BasketId")
                    .HasFillFactor((byte)10);

                entity.HasIndex(e => e.Date, "IX_Incomes_Date")
                    .HasFillFactor((byte)10);

                entity.Property(e => e.Amount).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.Incomes)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Incomes_Baskets");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Name, "UK_Products_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
