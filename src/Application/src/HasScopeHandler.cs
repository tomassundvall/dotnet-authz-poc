using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Application
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override Task HandleAsync(AuthorizationHandlerContext context)
        {
            Console.WriteLine("TEST AuthorizationHandlerContext");
            return base.HandleAsync(context);
        }


        public override string ToString()
        {
            return base.ToString();
        }


        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasScopeRequirement requirement)
        {
            Console.WriteLine("Authorize..." + context.User.Claims.Count());

            // If the user does not have the scope claim, get out of here
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
            {
                Console.WriteLine("Lacked scope...");
                return Task.CompletedTask;
            }

            // Split the scopes string into an array
            string[] scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');
            Console.WriteLine(JsonConvert.SerializeObject(scopes, Formatting.Indented));
            
            // Succeed if the scope array contains the required scope
            if (scopes.Any(s => s == requirement.Scope))
            {
                context.Succeed(requirement);
            }

            Console.WriteLine("WTF...");
            return Task.CompletedTask;
        }
    }
}