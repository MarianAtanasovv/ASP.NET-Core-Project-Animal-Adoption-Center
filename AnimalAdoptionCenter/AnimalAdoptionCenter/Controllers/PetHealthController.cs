using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Controllers
{
    public class PetHealthController : Controller
    {
        [HttpGet]
        public IActionResult CatDogNutrition()
        {
            return View();
        }
        [HttpGet]
        public IActionResult BasicDogCare()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DogBehaviourAndTraining()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DogHealth()
        {
            return View();
        }
   

        [HttpGet]
        public IActionResult BasicCatCare()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CatBehaviourAndTraining()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CatHealth()
        {
            return View();
        }
       
    }
}
