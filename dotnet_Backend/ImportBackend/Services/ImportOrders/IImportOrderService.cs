using ImportBackend.Models;

namespace ImportBackend.Services.ImportOrders
{
    public interface IImportOrderService
    {
        void CreateImportOrder(ImportOrder importOrder);
        void DeleteImportOrder(int id);
        ImportOrder GetImportOrder(int id);
        void UpsertImportOrder(ImportOrder importOrder);
        public IEnumerable<ImportOrder> GetImportOrders();
    }
}