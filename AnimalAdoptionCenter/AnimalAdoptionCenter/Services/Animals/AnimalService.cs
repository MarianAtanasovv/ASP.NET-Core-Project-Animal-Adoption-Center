//using AnimalAdoptionCenter.Data;
//using AnimalAdoptionCenter.Data.Models;
//using AnimalAdoptionCenter.Models.Animals;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.IO;

//namespace AnimalAdoptionCenter.Services.Animals
//{
//    public class AnimalService : IAnimalService
//    {
//        private readonly ApplicationDbContext data;
//        private readonly IWebHostEnvironment webHostEnvironment;
//        public AnimalService(ApplicationDbContext data, IWebHostEnvironment hostEnvironment)
//        {
//            this.data = data;
//            this.webHostEnvironment = hostEnvironment;
//        }

//        public int Add(int id,
//            string name, 
//            int age, 
//            string breed,
//            Data.Models.Type type, 
//            Gender gender,
//            bool aggressive)
//        {
//            var animal = new Animal
//            {
//                Id = id,
//                Name = name,
//                Age = age,
//                Breed = breed,
//                Type = type,
//                Gender = gender,
//                Agressive = aggressive
//            };

//            foreach (var image in animalModel.Images)
//            {
//                var uniqueFileName = UploadedFile(image);
//                var animalImageData = new Image
//                {
//                    Name = uniqueFileName,
//                    AnimalId = animal.Id
//                };

//                this.data.Images.Add(image);
//                animal.AnimalImages.Add(animalImageData);
 
//            }

//            this.data.Animals.Add(animal);
//            this.data.SaveChanges();

//            return animal.Id;
//        }


//        private string UploadedFile(IFormFile imageData)
//        {
//            string uniqueFileName = null;

//            if (imageData != null)
//            {
//                var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "databaseFiles/Animals");
//                uniqueFileName = Guid.NewGuid() + "_" + imageData.FileName;
//                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
//                using var fileStream = new FileStream(filePath, FileMode.Create);
//                imageData.CopyTo(fileStream);
//            }

//            return uniqueFileName;
//        }
//    }
  
//}
