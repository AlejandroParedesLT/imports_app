using ImportBackend.Models;

namespace ImportBackend.Services.ProductCategories
{
    public interface IProductCategoryService
    {
        void CreateProductCategory(ProductCategory product);
        void DeleteProductCategory(int id);
        ProductCategory GetProductCategory(int id);
        void UpsertProductCategory(ProductCategory product);
        public IEnumerable<ProductCategory> GetProductCategories();
    }
}