using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace ui.Auth;

public class JwtAuthenticationStateProvider
 : AuthenticationStateProvider
{
    private readonly Task<AuthenticationState> authenticationState;

    public JwtAuthenticationStateProvider(AuthenticatedUser user) => authenticationState = Task.FromResult(new AuthenticationState(user.Principal));

    public override Task<AuthenticationState> GetAuthenticationStateAsync() => authenticationState;

}
public class AuthenticatedUser
{
    public ClaimsPrincipal Principal { get; set; } = new();
}
