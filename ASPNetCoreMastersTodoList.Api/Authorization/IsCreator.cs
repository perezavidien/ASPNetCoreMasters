using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.Api.Authorization
{
    public class IsCreatorRequirement : IAuthorizationRequirement { }
    public class IsCreator : AuthorizationHandler<IsCreatorRequirement, ItemDTO>
    {
        private UserManager<IdentityUser> _userManager;

        public IsCreator(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsCreatorRequirement requirement,
            ItemDTO resource)
        {
            var user = await _userManager.GetUserAsync(context.User);

            if (user != null)
            {
                return;
            }

            if (resource.CreatedBy == user.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}
