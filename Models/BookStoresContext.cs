using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BSI.Models
{
    public partial class BookStoresContext : DbContext
    {
        public BookStoresContext()
        {
        }

        public BookStoresContext(DbContextOptions<BookStoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Return> Returns { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleClaim> RoleClaims { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerCity)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Customer_City");

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Customer_email");

                entity.Property(e => e.CustomerPcode)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Customer_PCode");

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Customer_phone");

                entity.Property(e => e.CustomerStreet)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Street");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("First_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Last_name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Order_ID");

                entity.Property(e => e.CreditCardExpiry)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Credit_card_expiry");

                entity.Property(e => e.CreditCardNumb)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Credit_card_numb");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.OrderDate)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Order_Date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__30F848ED");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__Order_It__3FB50F94051AB654");

                entity.ToTable("Order_Items");

                entity.Property(e => e.ItemId)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Item_ID");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("isbn");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Order_ID");

                entity.Property(e => e.QtySold)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Qty_sold");

                entity.Property(e => e.RetailPrice)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Retail_Price");

                entity.Property(e => e.StockId)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Stock_ID");

                entity.Property(e => e.SupplierId)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__Order__2E1BDC42");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__Stock__2F10007B");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__Suppl__300424B4");
            });

            modelBuilder.Entity<Return>(entity =>
            {
                entity.Property(e => e.ReturnId)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Return_ID");

                entity.Property(e => e.ItemId)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Item_ID");

                entity.Property(e => e.RetailPrice)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Retail_Price");

                entity.Property(e => e.StockId)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Stock_ID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Returns__Item_ID__31EC6D26");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.Returns)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Returns__Stock_I__32E0915F");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_RoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.StockId)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("STOCK_ID");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Author_name");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("isbn");

                entity.Property(e => e.PublishedYear)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Published_year");

                entity.Property(e => e.PublisherName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Publisher_name");

                entity.Property(e => e.RetailPrice)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Retail_price");

                entity.Property(e => e.SupplierId)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_ID");

                entity.Property(e => e.TitleName)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Title_name");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_ID");

                entity.Property(e => e.StockId)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Stock_ID");

                entity.Property(e => e.SupplierCity)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_City");

                entity.Property(e => e.SupplierEmail)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_email");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_name");

                entity.Property(e => e.SupplierPcode)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_PCode");

                entity.Property(e => e.SupplierPhone)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_phone");

                entity.Property(e => e.SupplierStreet)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_Street");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Suppliers__Stock__33D4B598");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_UserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
