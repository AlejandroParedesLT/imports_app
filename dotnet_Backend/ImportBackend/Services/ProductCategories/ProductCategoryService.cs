using ImportBackend.Data;
using ImportBackend.Models;

namespace ImportBackend.Services.ProductCategories
{
    public class ProductCategoryService : IProductCategoryService
    {
        public void CreateProductCategory(ProductCategory productCategory)
        {
            using (var db = new OracleDBContext())
            {
                db.ProductCategories.Add(productCategory);
                db.SaveChanges();
            }
        }

        public ProductCategory GetProductCategory(int id)
        {
            using (var db = new OracleDBContext())
            {
                var productCategory = db.ProductCategories.Find(id);
                return productCategory;
            }
        }

        public void DeleteProductCategory(int id)
        {
            using (var db = new OracleDBContext())
            {
                var productCategory = db.ProductCategories.Find(id);
                if (productCategory != null)
                {
                    db.ProductCategories.Remove(productCategory);
                    db.SaveChanges();
                }
            }
        }

        public void UpsertProductCategory(ProductCategory productCategory)
        {
            using (var db = new OracleDBContext())
            {
                db.ProductCategories.Attach(productCategory);
                var entry = db.Entry(productCategory);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.Description).IsModified = true;
                entry.Property(e => e.DateUpdated).IsModified = true;
                db.SaveChanges();
            }
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            using (var db = new OracleDBContext())
            {
                var productCategories = db.ProductCategories.ToList();
                return productCategories;
            }
        }
    }
}
