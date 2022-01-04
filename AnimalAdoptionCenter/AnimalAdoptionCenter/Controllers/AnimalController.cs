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
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddAnimalFormModel animalModel)
        {

            if (!ModelState.IsValid)
            {
                return View(animalModel);
            }

            this.animal.Add(animalModel);
            

            return RedirectToAction("Index", "Home", new { area = "" });
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

        public IActionResult Remove(int id)
        {
            var dog = this.animal.Remove(id);

            if (dog == 0)
            {
                return NotFound();
            }

            return RedirectToAction("All", "Animal");

        }

        private string UploadedFile(IFormFile imageData)
        {
            string uniqueFileName = null;

            if (imageData != null)
            {
                var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "databaseFiles/Animals");
                uniqueFileName = Guid.NewGuid() + "_" + imageData.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                imageData.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

    }
}
