using ImportBackend.Data;
using ImportBackend.Models;

namespace ImportBackend.Services.ImportOrders
{
    public class ImportOrderService : IImportOrderService
    {
        public void CreateImportOrder(ImportOrder importOrder)
        {
            using (var db = new OracleDBContext())
            {
                db.ImportOrders.Add(importOrder);
                db.SaveChanges();
            }
        }
        public ImportOrder GetImportOrder(int id)
        {
            using (var db = new OracleDBContext())
            {
                var importOrder = db.ImportOrders.Find(id);
                return importOrder;
            }
        }
        public void DeleteImportOrder(int id)
        {
            using (var db = new OracleDBContext())
            {
                var importOrder = db.ImportOrders.Find(id);
                if (importOrder != null)
                {
                    db.ImportOrders.Remove(importOrder);
                    db.SaveChanges();
                }
            }
        }

        public void UpsertImportOrder(ImportOrder importOrder)
        {
            using (var db = new OracleDBContext())
            {
                db.ImportOrders.Attach(importOrder);
                var entry = db.Entry(importOrder);
                entry.Property(e => e.UserId).IsModified = true;
                entry.Property(e => e.ProductId).IsModified = true;
                entry.Property(e => e.ProviderId).IsModified = true;
                entry.Property(e => e.Quantity).IsModified = true;
                entry.Property(e => e.Individualprice).IsModified = true;
                entry.Property(e => e.Description).IsModified = true;
                entry.Property(e => e.DateCreated).IsModified = true;
                entry.Property(e => e.DateUpdated).IsModified = true;
                db.SaveChanges();
            }
        }

        public IEnumerable<ImportOrder> GetImportOrders()
        {
            using (var db = new OracleDBContext())
            {
                var importOrder = db.ImportOrders.ToList();
                return importOrder;
            }
        }
    }
}
