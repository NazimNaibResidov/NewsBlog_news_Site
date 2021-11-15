using System.Collections.Generic;
using System.Security.Claims;

namespace NewsBlog.Base.BaseServices
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        ClaimsIdentity UserIdentity { get; }

        bool HasClaim(string claimName);

        Claim GetUserClaim(string claimType);

        string GetUserClaimValue(string claimName);

        IEnumerable<Claim> GetUserClaims();
    }
}