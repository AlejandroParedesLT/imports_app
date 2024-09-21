using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportBackend.Contracts.User
{
    public record UserResponse
    (
        int Id,
        string GivenName,
        string LastName,
        string UserName,
        string Email,
        string Password,
        DateTime DateCreated,
        DateTime DateUpdated
    );
}
