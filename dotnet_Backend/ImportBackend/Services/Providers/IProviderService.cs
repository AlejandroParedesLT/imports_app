using ImportBackend.Models;

namespace ImportBackend.Services.Providers
{
    public interface IProviderService
    {
        void CreateProvider(Provider provider);
        void DeleteProvider(int id);
        Provider GetProvider(int id);
        void UpsertProvider(Provider provider);
        IEnumerable<Provider> GetProviders();
    }
}
