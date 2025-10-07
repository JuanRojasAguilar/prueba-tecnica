using Microsoft.AspNetCore.Identity;

namespace api.Application.Interfaces;

public interface ITokenService
{
    string CreateToken(IdentityUser admin);
}
