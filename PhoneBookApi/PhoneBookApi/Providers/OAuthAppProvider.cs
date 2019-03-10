using Microsoft.Owin.Security.OAuth;
using PhoneBookApi.Models;
using PhoneBookApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace PhoneBookApi.Providers
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var userRepository = new UserRepository();
            User user = userRepository.Get(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "the user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

            context.Validated(identity);
        }
    }
}