using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBackend.Contracts.Client
{
    public record CreateClientRequest(
        string GivenName,
        string LastName,
        string UserName,
        string Password,
        DateTime DateCreated,
        DateTime DateUpdated
    );
}
