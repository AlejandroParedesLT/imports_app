using ImportBackend.Models;
using Microsoft.EntityFrameworkCore;
//using Oracle.ManagedDataAccess.Client;
using System.Reflection.Metadata;
using Oracle.EntityFrameworkCore;
using System.Xml.Linq;
using System.Diagnostics.Metrics;
//using Microsoft.EntityFrameworkCore;

namespace ImportBackend.Data
{
    public class OracleDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ImportOrder> ImportOrders { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=django_client;Password=123456;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));");
        }
        //public OracleDBContext(DbContextOptions<OracleDBContext> options) : base(options)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("PRODUCTS", "DJANGO_CLIENT");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(50);
            modelBuilder.Entity<Product>().Property(p => p.DateCreated).HasColumnType("TIMESTAMP");
            modelBuilder.Entity<Product>().Property(p => p.DateUpdated).HasColumnType("TIMESTAMP");
            modelBuilder.Entity<Product>().Property(p => p.Image).HasColumnType("BLOB");
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductCategory)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ProductCategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_ProductCategory");



            modelBuilder.Entity<User>().ToTable("USERS", "DJANGO_CLIENT");
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<User>().Property(p => p.GivenName).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.DateCreated).HasColumnType("TIMESTAMP");
            modelBuilder.Entity<User>().Property(p => p.DateUpdated).HasColumnType("TIMESTAMP");

            modelBuilder.Entity<ProductCategory>().ToTable("PRODUCT_CATEGORY", "DJANGO_CLIENT");
            modelBuilder.Entity<ProductCategory>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductCategory>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<ProductCategory>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<ProductCategory>().Property(p => p.Description).IsRequired();
            modelBuilder.Entity<ProductCategory>().Property(p => p.DateCreated).HasColumnType("TIMESTAMP");
            modelBuilder.Entity<ProductCategory>().Property(p => p.DateUpdated).HasColumnType("TIMESTAMP");

            modelBuilder.Entity<ImportOrder>().ToTable("IMPORT_ORDERS", "DJANGO_CLIENT");
            modelBuilder.Entity<ImportOrder>().HasKey(p => p.Id);
            modelBuilder.Entity<ImportOrder>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<ImportOrder>().Property(p => p.UserId).IsRequired().HasColumnType("INT");
            modelBuilder.Entity<ImportOrder>().Property(p => p.ProductId).IsRequired().HasColumnType("INT");
            modelBuilder.Entity<ImportOrder>().Property(p => p.ProviderId).IsRequired().HasColumnType("INT");
            modelBuilder.Entity<ImportOrder>().Property(p => p.Quantity).IsRequired().HasColumnType("INT");
            modelBuilder.Entity<ImportOrder>().Property(p => p.Individualprice).IsRequired().HasColumnType("DECIMAL(18,4)");
            modelBuilder.Entity<ImportOrder>().Property(p => p.Description).HasColumnType("VARCHAR(4000)"); ;
            modelBuilder.Entity<ImportOrder>().Property(p => p.DateCreated).HasColumnType("TIMESTAMP");
            modelBuilder.Entity<ImportOrder>().Property(p => p.DateUpdated).HasColumnType("TIMESTAMP");

            modelBuilder.Entity<Provider>().ToTable("PROVIDERS", "DJANGO_CLIENT");
            modelBuilder.Entity<Provider>().HasKey(p => p.Id);
            modelBuilder.Entity<Provider>().Property(p => p.Id).UseIdentityColumn();
            modelBuilder.Entity<Provider>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Provider>().Property(p => p.Email).IsRequired();
            modelBuilder.Entity<Provider>().Property(p => p.PhoneNumber).IsRequired().HasColumnType("INT");
            modelBuilder.Entity<Provider>().Property(p => p.Country).IsRequired();
            modelBuilder.Entity<Provider>().Property(p => p.DateCreated).HasColumnType("TIMESTAMP");
            modelBuilder.Entity<Provider>().Property(p => p.DateUpdated).HasColumnType("TIMESTAMP");
        }
    }
}
