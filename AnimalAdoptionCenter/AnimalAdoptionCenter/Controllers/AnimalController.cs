using AnimalAdoptionCenter.Models.Animal;
using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Animals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using AnimalAdoptionCenter.Infrastructure;

namespace AnimalAdoptionCenter.Controllers
{
    public class AnimalController : Controller
    {

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAnimalService animal;
        public AnimalController(IWebHostEnvironment hostEnvironment, IAnimalService animal)
        {
            this.webHostEnvironment = hostEnvironment;
            this.animal = animal;
        }


        [HttpGet]
        public IActionResult All([FromQuery] AllAnimalsQueryModel query)
        {
            var animalsQueryResult = this.animal.All(
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllAnimalsQueryModel.AnimalsPerPage,
                query.Name);

            var animalsNames = this.animal.AllAnimals();
              
            query.TotalAnimals = animalsQueryResult.TotalAnimals;
            query.Animals = animalsQueryResult.Animals;
            query.Names = animalsNames;
            
            return this.View(query);
        }


        

        [HttpGet]
        public IActionResult Details(int id, string information)
        {

            var animal = this.animal.Details(id);

            if (animal == null)
            {
                return NotFound();
            }
            if (information != animal.GetInformationAnimal())
            {
                return Unauthorized();
            }

            return View(new AnimalDetailsServiceModel
            {
                Id = animal.Id,
                Name = animal.Name,
                Description = animal.Description,
                Color = animal.Color,
                Breed = animal.Breed,
                Age = animal.Age,
                Aggressive = animal.Aggressive,
                Gender = animal.Gender,
                Images = animal.Images,
                Neutered = animal.Neutered,
                Vaccinated = animal.Vaccinated
            });

        }

      
    }
}
