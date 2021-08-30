using AnimalAdoptionCenter.Data;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext data;

        public AnimalController(ApplicationDbContext data)
        {
            this.data = data;
        }
        

        public IActionResult Add()
        {
            return View();
        }
    }
}
