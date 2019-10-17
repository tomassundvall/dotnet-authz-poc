using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Application
{
    public class AuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        private readonly AuthorizationOptions _options;
        private readonly IConfiguration _config;


        public AuthorizationPolicyProvider(
            IOptions<AuthorizationOptions> options,
            IConfiguration config) : base(options)
        {
            _options = options.Value;
            _config = config;
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override async Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
        {
            // Check static policies first
            var policy = await base.GetPolicyAsync(policyName);

            if (policy == null)
            {
                policy = new AuthorizationPolicyBuilder()
                    .AddRequirements(new HasScopeRequirement(policyName, "https://jerrie.auth0.com/"))
                    .Build();

                _options.AddPolicy(policyName, policy);
            }

            return policy;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}