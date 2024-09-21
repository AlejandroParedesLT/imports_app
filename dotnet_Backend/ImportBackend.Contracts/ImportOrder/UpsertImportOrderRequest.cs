using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBackend.Contracts.ImportOrder
{
    public record UpsertProviderRequest(
        int Id,
        int UserId,
        int ProductId,
        int ProviderId,
        int Quantity,
        float Individualprice,
        string? Description,
        DateTime DateCreated,
        DateTime DateUpdated
    );
}
