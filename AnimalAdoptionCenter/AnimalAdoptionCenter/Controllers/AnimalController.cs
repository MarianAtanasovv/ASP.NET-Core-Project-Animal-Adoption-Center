using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models.Animals;
using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Animals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace AnimalAdoptionCenter.Controllers
{
    public class AnimalController : Controller
    {

        private readonly ApplicationDbContext data;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAnimalService animal;
        public AnimalController(ApplicationDbContext data, IWebHostEnvironment hostEnvironment, IAnimalService animal)
        {
            this.data = data;
            this.webHostEnvironment = hostEnvironment;
            this.animal = animal;
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

            var animal = new Animal
            {
                Id = animalModel.Id,
                Name = animalModel.Name,
                Age = animalModel.Age,
                Breed = animalModel.Breed,
                Color = animalModel.Color,
                Description = animalModel.Description,
                Type = animalModel.Type,
                Gender = animalModel.Gender,
                Agressive = animalModel.Agressive
            };

            foreach (var image in animalModel.Images)
            {
                var uniqueFileName = UploadedFile(image);
                var animalImageData = new Image
                {
                    Name = uniqueFileName,
                    AnimalId = animal.Id
                };

                this.data.Images.Add(animalImageData);
                animal.AnimalImages.Add(animalImageData);

            }

            this.data.Animals.Add(animal);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Details(int id)
        {

            var animal = this.animal.Details(id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(new AnimalDetailsServiceModel
            {
                Id = animal.Id,
                Name = animal.Name,
                Description = animal.Description,
                Color = animal.Color,
                Breed = animal.Breed,
                Age = animal.Age,
                Type = animal.Type,
                Agressive = animal.Agressive,
                Gender = animal.Gender,
                Images = animal.Images
            });

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
