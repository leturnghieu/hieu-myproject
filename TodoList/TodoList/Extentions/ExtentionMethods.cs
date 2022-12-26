using System;
using System.Security.Claims;

namespace TodoList.Extentions
{
    public static class ExtentionMethods
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            return Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
