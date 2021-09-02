using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models.Animals;
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
        public AnimalController(ApplicationDbContext data, IWebHostEnvironment hostEnvironment)
        {
            this.data = data;
            this.webHostEnvironment = hostEnvironment;
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
