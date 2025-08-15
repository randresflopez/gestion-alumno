using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AlumnosApi.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder)
        : base(options, logger, encoder) { }
                protected override Task<AuthenticateResult> HandleAuthenticateAsync()
{
    // Verifica si el encabezado "Authorization" existe
    if (!Request.Headers.ContainsKey("Authorization"))
    {
        return Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));
    }

    var authHeaderValue = Request.Headers["Authorization"].FirstOrDefault();

    if (string.IsNullOrEmpty(authHeaderValue))
    {
        return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header format"));
    }

    try
    {
        var authHeader = AuthenticationHeaderValue.Parse(authHeaderValue);

        if (string.IsNullOrEmpty(authHeader.Parameter))
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header format"));
        }

        var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
        var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
        var username = credentials[0];
        var password = credentials[1];

        if (username == "admin" && password == "password")
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
        else
        {
            return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));
        }
    }
    catch
    {
        return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header format"));
    }
}
    }
}