using System.Threading.Tasks;
using PurchaseC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PurchaseC.Data;

namespace PurchaseC.Authorization
{

    //public class ContactAdministratorsAuthorizationHandler
    //                : AuthorizationHandler<OperationAuthorizationRequirement, Computer>
    //{
    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,OperationAuthorizationRequirement requirement,Computer resource)
    //    {
    //        if (context.User == null)
    //        {
    //            return Task.CompletedTask;
    //        }

    //        // Administrators can do anything.
    //        if (context.User.IsInRole("Admin"))
    //        {
    //            context.Succeed(requirement);
    //        }
    //        /*else if (_userManager.GetUserId(context.User) == resource.OwnerID.
    //        {
    //            context.Succeed(requirement);
    //        }*/
           

    //        return Task.CompletedTask;
    //    }
    //}
}