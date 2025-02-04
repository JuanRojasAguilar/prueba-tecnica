using Microsoft.AspNetCore.Identity;

namespace api.Interfaces;

public interface TokenService
{
    string CreateToken(IdentityUser admin);
}
