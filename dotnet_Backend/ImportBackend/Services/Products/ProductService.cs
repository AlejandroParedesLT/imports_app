using ImportBackend.Data;
using ImportBackend.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.Metadata;

namespace ImportBackend.Services.Products
{
    public class ProductService : IProductService
    {
        public void CreateProduct(Product product)
        {
            using (var db = new OracleDBContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public Product GetProduct(int id)
        {
            using (var db = new OracleDBContext())
            {
                var product = db.Products
                    .Include(p => p.ProductCategory) // Include ProductCategory
                    .FirstOrDefault(p => p.Id == id);
                return product;
            }
        }

        public void DeleteProduct(int id)
        {
            using (var db = new OracleDBContext())
            {
                var product = db.Products.Find(id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
        }

        public void UpsertProduct(Product product)
        {
            using (var db = new OracleDBContext())
            {
                db.Products.Attach(product);
                var entry = db.Entry(product);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.Description).IsModified = true;
                entry.Property(e => e.DateUpdated).IsModified = true;
                entry.Property(e => e.ProductCategoryId).IsModified = true;
                entry.Property(e => e.Image).IsModified = true;
                db.SaveChanges();
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var db = new OracleDBContext())
            {
                var products = db.Products.Include(p => p.ProductCategory).ToList();
                return products;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string categoryId)
        {
            using (var db = new OracleDBContext())
            {
                var products = new List<Product>();

                // Create Oracle parameters
                var categoryIdParam = new OracleParameter("categoryId", OracleDbType.Varchar2, ParameterDirection.Input) { Value = categoryId };
                var productsParam = new OracleParameter("products", OracleDbType.RefCursor, ParameterDirection.Output);

                // Call stored procedure
                var query = "BEGIN GetProductsByCategory(:categoryId, :products); END;";
                products = db.Products
                                .FromSqlRaw(query, categoryIdParam, productsParam)
                                .ToList();

                return products;
            }
        }
    }
}
