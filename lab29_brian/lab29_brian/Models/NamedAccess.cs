using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace lab29_brian.Models
{
    public class NamedAccess : AuthorizationHandler<BriansOnly>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BriansOnly requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role))
            {
                return Task.CompletedTask;
            }

            var result = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Any(c => c.Value == "Brian Only");
                //(c => c.Value == "Brian Only").Value;

            if (result)
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}
