using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBackend.Contracts.Product
{
    public record ImportOrderResponse(
        int Id,
        string? Name,
        string? Description,
        DateTime DateCreated,
        DateTime DateUpdated,
        string? Category,
        byte[]? Image
    );
}
