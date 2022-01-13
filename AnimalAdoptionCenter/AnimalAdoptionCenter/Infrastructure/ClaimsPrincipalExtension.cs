using System.Linq;
using AnimalAdoptionCenter.Areas.Administration;
using System.Security.Claims;
using Microsoft.Ajax.Utilities;

namespace AnimalAdoptionCenter.Infrastructure
{
    using static AdministrationConstants;
    public static class ClaimsPrincipalExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdministratorRoleName);
        }
        public static string Name(this ClaimsPrincipal user)
        {
            string usernameValue = null;
            if (user.Identity is ClaimsIdentity claimsIdentity)
            {
                var username = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
                if (username != null)
                {
                    usernameValue = username.Value;
                }
            }

            return usernameValue;
            
        }
    }
}
