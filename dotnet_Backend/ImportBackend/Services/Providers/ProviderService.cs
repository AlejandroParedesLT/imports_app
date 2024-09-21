using ImportBackend.Data;
using ImportBackend.Models;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace ImportBackend.Services.Providers
{
    public class ProviderService : IProviderService
    {
        public void CreateProvider(Provider provider)
        {
            using (var db = new OracleDBContext())
            {
                db.Providers.Add(provider);
                db.SaveChanges();
            }
        }

        public Provider GetProvider(int id)
        {
            using (var db = new OracleDBContext())
            {
                var provider = db.Providers.Find(id);
                return provider;
            }
        }

        public void DeleteProvider(int id)
        {
            using (var db = new OracleDBContext())
            {
                var provider = db.Providers.Find(id);
                if (provider != null)
                {
                    db.Providers.Remove(provider);
                    db.SaveChanges();
                }
            }
        }

        public void UpsertProvider(Provider provider)
        {
            using (var db = new OracleDBContext())
            {
                db.Providers.Attach(provider);
                var entry = db.Entry(provider);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.Email).IsModified = true;
                entry.Property(e => e.PhoneNumber).IsModified = true;
                entry.Property(e => e.Country).IsModified = true;
                entry.Property(e => e.DateUpdated).IsModified = true;
                db.SaveChanges();
            }
        }

        public IEnumerable<Provider> GetProviders()
        {
            using (var db = new OracleDBContext())
            {
                var providers = db.Providers.ToList();
                return providers;
            }
        }
    }
}
