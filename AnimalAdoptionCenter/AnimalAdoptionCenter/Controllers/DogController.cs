using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
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
    public class DogController : Controller
    {

        private readonly ApplicationDbContext data;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IDogService dog;
        public DogController(ApplicationDbContext data, IWebHostEnvironment hostEnvironment, IDogService animal)
        {
            this.data = data;
            this.webHostEnvironment = hostEnvironment;
            this.dog = animal;
        }


        [HttpGet]
        public IActionResult All([FromQuery] AllDogsQueryModel query)
        {
            var dogsQueryResult = this.dog.All(
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllDogsQueryModel.DogsPerPage,
                query.Name);

            var dogNames = this.dog.AllDogs();
              
            query.TotalDogs = dogsQueryResult.TotalDogs;
            query.Dogs = dogsQueryResult.Dogs;
            query.Names = dogNames;
            
            return this.View(query);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddDogFormModel dogModel)
        {

            if (!ModelState.IsValid)
            {
                return View(dogModel);
            }

            var dog = new Dog
            {
                Id = dogModel.Id,
                Name = dogModel.Name,
                Age = dogModel.Age,
                Breed = dogModel.Breed,
                Color = dogModel.Color,
                Description = dogModel.Description,
                Gender = dogModel.Gender,
                Agressive = dogModel.Agressive,
                Health = dogModel.Health
            };

            foreach (var image in dogModel.Images)
            {
                var uniqueFileName = UploadedFile(image);
                var animalImageData = new Image
                {
                    Name = uniqueFileName,
                    AnimalId = dog.Id
                };

                this.data.Images.Add(animalImageData);
                dog.AnimalImages.Add(animalImageData);

            }

            this.data.Dogs.Add(dog);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var dog = this.dog.Details(id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(new DogDetailsServiceModel
            {
                Id = dog.Id,
                Name = dog.Name,
                Description = dog.Description,
                Color = dog.Color,
                Breed = dog.Breed,
                Age = dog.Age,
                Agressive = dog.Agressive,
                Gender = dog.Gender,
                Images = dog.Images,
                Health = dog.Health
            });

        }

        public IActionResult Remove(int id)
        {
            var dog = this.dog.Remove(id);

            if (dog == 0)
            {
                return NotFound();
            }

            return RedirectToAction("All", "Dog");

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
