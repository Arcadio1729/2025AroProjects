using aroshopapi.Dtos;
using aroshopapi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace aroshopapi.Authorize
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, User>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            ResourceOperationRequirement requirement,
            User userDetails)
        {
            var userId = context.User.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;

            if(userDetails.Id == userId)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
