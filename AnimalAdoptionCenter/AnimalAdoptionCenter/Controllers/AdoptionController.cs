using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Controllers
{
    public class AdoptionController : Controller
    {
        [HttpGet]
        public IActionResult Interview()
        {
            return this.View();
        }
    }
}
