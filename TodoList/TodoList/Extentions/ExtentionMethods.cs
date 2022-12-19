using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Security.Principal;
using TodoList.Models;

namespace TodoList.Extentions
{
    public static class ExtentionMethods
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
