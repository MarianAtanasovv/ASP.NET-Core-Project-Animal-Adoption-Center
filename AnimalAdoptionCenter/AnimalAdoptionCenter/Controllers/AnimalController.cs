using AnimalAdoptionCenter.Models.Animal;
using AnimalAdoptionCenter.Models.Animals;
using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Animals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

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
        public IActionResult Details(int id)
        {

            var dog = this.animal.Details(id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(new AnimalDetailsServiceModel
            {
                Id = dog.Id,
                Name = dog.Name,
                Description = dog.Description,
                Color = dog.Color,
                Breed = dog.Breed,
                Age = dog.Age,
                Aggressive = dog.Aggressive,
                Gender = dog.Gender,
                Images = dog.Images,
                Neutered = dog.Neutered,
                Vaccinated = dog.Vaccinated
            });

        }

      
    }
}
