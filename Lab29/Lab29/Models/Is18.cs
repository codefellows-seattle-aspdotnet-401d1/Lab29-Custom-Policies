﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lab29.Models
{
    public class Is18 : AuthorizationHandler<MinimumAgeRequirment>
    {
        private const int minAge = 18;
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirment requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;

            }

            var birthday = Convert.ToDateTime(context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth).Value);

            int age = DateTime.Compare(DateTime.Now, birthday);

            if (age >= minAge)
            {
                context.Succeed(requirement);
            }


            return Task.CompletedTask;
        }
    }
}
