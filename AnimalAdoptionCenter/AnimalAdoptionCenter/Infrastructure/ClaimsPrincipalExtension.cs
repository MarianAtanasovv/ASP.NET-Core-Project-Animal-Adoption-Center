using AnimalAdoptionCenter.Areas.Administration;
using System.Security.Claims;

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
    }
}
