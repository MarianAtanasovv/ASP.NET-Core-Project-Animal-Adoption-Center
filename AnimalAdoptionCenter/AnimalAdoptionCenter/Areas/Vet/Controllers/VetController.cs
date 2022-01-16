using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Areas.Vet.Controllers
{
    using static VetConstants;
    [Authorize(Roles = VetRoleName)]
    [Area(AreaName)]
    public class VetController : Controller
    {
    }
}
