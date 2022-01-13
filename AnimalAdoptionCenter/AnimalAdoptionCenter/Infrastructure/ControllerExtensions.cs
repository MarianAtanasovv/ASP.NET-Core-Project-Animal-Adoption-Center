using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Infrastructure
{
    public static class ControllerExtensions
    {

        public static string GetControllerName(this Type controllerType)
            => controllerType.Name.Replace(nameof(Controller), string.Empty);
    }
}
