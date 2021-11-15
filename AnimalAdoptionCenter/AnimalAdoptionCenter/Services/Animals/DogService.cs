using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models.Animal;
using AnimalAdoptionCenter.Models.Animals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class DogService : IDogService
    {
        private readonly ApplicationDbContext data;
        private readonly IWebHostEnvironment webHostEnvironment;

        public DogService(ApplicationDbContext data, IWebHostEnvironment webHostEnvironment)
        {
            this.data = data;
            this.webHostEnvironment = webHostEnvironment;

        }

        public DogsQueryModel All(
          string searchTerm,
          AnimalSorting sorting,
          int currentPage,
          int dogsPerPage,
          string name)
        {
            var dogsQuery = this.data.Dogs.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                dogsQuery = dogsQuery.Where(x => x.Name == name);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dogsQuery = dogsQuery.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            dogsQuery = sorting switch
            {
                AnimalSorting.Name => dogsQuery.OrderBy(t => t.Name),
                AnimalSorting.Age => dogsQuery.OrderByDescending(p => p.Age),
                _ => dogsQuery.OrderByDescending(x => x.Id)
            };

            var totalDogs = dogsQuery.Count();

            var dogs = GetDogs(dogsQuery
                .Skip((currentPage - 1) * dogsPerPage)
                .Take(dogsPerPage));


            return new DogsQueryModel
            {
                TotalDogs = totalDogs,
                Dogs = dogs,
                CurrentPage = currentPage,
                DogsPerPage = dogsPerPage
            };

        }

        public DogDetailsServiceModel Details(int id)
        {
            var details = this.data.Dogs.Include(x => x.AnimalImages).Where(x => x.Id == id)
            .Select(x => new DogDetailsServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Breed = x.Breed,
                Age = x.Age,
                Gender = x.Gender,
                Aggressive = x.Aggressive,
                Color = x.Color,
                Images = x.AnimalImages,
                Neutered = x.Neutered,
                Vaccinated = x.Vaccinated

            })
              .FirstOrDefault();

            return details;
        }

        private static IEnumerable<DogServiceModel> GetDogs(IQueryable<Dog> dogQuery)
        {
            return dogQuery
           .Select(g => new DogServiceModel
           {
               Id = g.Id,
               Name = g.Name,
               Description = g.Description,
               Age = g.Age,
               AnimalImages = g.AnimalImages,
               Aggressive = g.Aggressive,
               Breed = g.Breed,
               Color = g.Color,
               Gender = g.Gender.ToString(),
               Neutered = g.Neutered,
               Vaccinated = g.Vaccinated

           })
           .ToList();
        }
        public IEnumerable<string> AllDogs()
        {
            return this.data
                .Dogs
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public int Remove(int id)
        {
            var dog = this.data.Dogs.Where(x => x.Id == id).FirstOrDefault();

            this.data.Dogs.Remove(dog);
            this.data.SaveChanges();

            return dog.Id;
        }



        public int Add(AddDogFormModel dogModel)
        {

            var dog = new Dog
            {
                Id = dogModel.Id,
                Name = dogModel.Name,
                Age = dogModel.Age,
                Breed = dogModel.Breed,
                Color = dogModel.Color,
                Description = dogModel.Description,
                Gender = dogModel.Gender,
                Aggressive = dogModel.Aggressive,
                Neutered = dogModel.Neutered,
                Vaccinated = dogModel.Vaccinated
            };

            foreach (var image in dogModel.Images)
            {
                var uniqueFileName = UploadedFile(image);
                var animalImageData = new AnimalImage
                {
                    Name = uniqueFileName,
                    AnimalId = dog.Id
                };

                this.data.Images.Add(animalImageData);
                dog.AnimalImages.Add(animalImageData);

            }

            this.data.Dogs.Add(dog);
            this.data.SaveChanges();

            return dog.Id;
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
