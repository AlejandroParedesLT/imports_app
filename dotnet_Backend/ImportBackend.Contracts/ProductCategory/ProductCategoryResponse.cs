using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBackend.Contracts.ProductCategory
{
    public record ProductCategoryResponse(
        int Id,
        string? Name,
        string? Description,
        DateTime DateCreated,
        DateTime DateUpdated
    );
}
