using ImportBackend.Models;

namespace ImportBackend.Services.Products
{
    public interface IProductService
    {
        void CreateProduct(Product product);
        void DeleteProduct(int id);
        Product GetProduct(int id);
        void UpsertProduct(Product product);
        public IEnumerable<Product> GetProducts();
        public IEnumerable<Product> GetProductsByCategory(string categoryId);
    }
}
