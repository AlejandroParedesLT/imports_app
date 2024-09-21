using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBackend.Contracts.Product
{
    public record CreateProductRequest(
        string? Name,
        string? Description,
        DateTime DateCreated,
        DateTime DateUpdated,
        int ProductCategoryId,
        byte[]? Image
    );
}
