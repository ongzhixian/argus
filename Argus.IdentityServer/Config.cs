using System.Collections.Generic;
using IdentityServer4.Models;

namespace Argus.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                //new IdentityResources.Profile(), // Reminder: the OpenID Connect default example uses this identity resource.
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },

                
                 // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api1" }
                },

                // OpenID Connect implicit flow client (MVC)
                // Uncomment to accept clients authenticating via OpenID Connect
                // new Client
                // {
                //     ClientId = "mvc",
                //     ClientName = "MVC Client",
                //     AllowedGrantTypes = GrantTypes.Implicit,

                //     // where to redirect to after login
                //     RedirectUris = { "http://localhost:50190/signin-oidc" },

                //     // where to redirect to after logout
                //     PostLogoutRedirectUris = { "http://localhost:50190/signout-callback-oidc" },

                //     AllowedScopes = new List<string>
                //     {
                //         IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                //         IdentityServer4.IdentityServerConstants.StandardScopes.Profile
                //     }
                // }
            };
        }

        public static List<IdentityServer4.Test.TestUser> GetUsers()
        {
            return new List<IdentityServer4.Test.TestUser>
            {
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password"
                },
                new IdentityServer4.Test.TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password"
                }
            };
        }


    }
}