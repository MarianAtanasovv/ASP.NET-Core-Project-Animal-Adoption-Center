using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Areas.Administration.Controllers
{
    using static AdministrationConstants;
    [Authorize(Roles = AdministratorRoleName)]
    [Area(AreaName)]
    public class AdministrationController : Controller
    {
    
      
    }
}
