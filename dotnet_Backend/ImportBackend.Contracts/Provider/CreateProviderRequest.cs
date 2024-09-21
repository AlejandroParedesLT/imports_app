using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ImportBackend.Contracts.Provider
{
    public record CreateProviderRequest(
        string Name,
        string Email,
        int PhoneNumber, 
        string Country,
        DateTime DateCreated,
        DateTime DateUpdated
    );
}