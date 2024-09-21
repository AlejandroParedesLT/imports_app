using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBackend.Contracts.Provider
{
    public record ProviderResponse(
        int Id,
        string Name,
        string Email,
        int PhoneNumber,
        string Country,
        DateTime DateCreated,
        DateTime DateUpdated
    );
}
