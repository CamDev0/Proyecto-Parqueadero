using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Parking.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity(new List<Claim>
            {
            new Claim("FirstName", "Camilo"),
            new Claim("LastName", "Barrios"),
            new Claim(ClaimTypes.Name, "admin@yopmail.com"),
            new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }

}
