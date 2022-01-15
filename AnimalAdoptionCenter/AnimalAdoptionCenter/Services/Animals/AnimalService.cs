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
    public class AnimalService : IAnimalService
    {
        private readonly ApplicationDbContext data;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AnimalService(ApplicationDbContext data, IWebHostEnvironment webHostEnvironment)
        {
            this.data = data;
            this.webHostEnvironment = webHostEnvironment;

        }

        public AnimalQueryModel All(
          string searchTerm,
          AnimalSorting sorting,
          int currentPage,
          int animalsPerPage,
          string name)
        {
            var animalsQuery = this.data.Animals.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                animalsQuery = animalsQuery.Where(x => x.Name == name);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                animalsQuery = animalsQuery.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            animalsQuery = sorting switch
            {
                AnimalSorting.Name => animalsQuery.OrderBy(t => t.Name),
                AnimalSorting.Age => animalsQuery.OrderByDescending(p => p.Age),
                _ => animalsQuery.OrderByDescending(x => x.Id)
            };

            var totalAnimals = animalsQuery.Count();

            var dogs = GetAnimals(animalsQuery
                .Skip((currentPage - 1) * animalsPerPage)
                .Take(animalsPerPage));


            return new AnimalQueryModel
            {
                TotalAnimals = totalAnimals,
                Animals = dogs,
                CurrentPage = currentPage,
                AnimalsPerPage = animalsPerPage
            };

        }

        public AnimalDetailsServiceModel Details(int id)
        {
            var details = this.data.Animals.Include(x => x.AnimalImages).Where(x => x.Id == id)
            .Select(x => new AnimalDetailsServiceModel
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

        private static IEnumerable<AnimalServiceModel> GetAnimals(IQueryable<Animal> animalQuery)
        {
            return animalQuery
           .Select(g => new AnimalServiceModel
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
        public IEnumerable<string> AllAnimals()
        {
            return this.data
                .Animals
                .Select(x => x.Name)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        public int Remove(int id)
        {
            var animal = this.data.Animals.Single(x => x.Id == id);
            this.data.Animals.Remove(animal);
            this.data.SaveChanges();

            return animal.Id;
        }



        public int Add(AddAnimalFormModel animalModel)
        {

            var animal = new Animal
            {
                Id = animalModel.Id,
                Name = animalModel.Name,
                Age = animalModel.Age,
                Breed = animalModel.Breed,
                Color = animalModel.Color,
                Description = animalModel.Description,
                Gender = animalModel.Gender,
                Aggressive = animalModel.Aggressive,
                Neutered = animalModel.Neutered,
                Vaccinated = animalModel.Vaccinated
            };

            foreach (var image in animalModel.Images)
            {
                var uniqueFileName = UploadedFile(image);
                var animalImageData = new AnimalImage
                {
                    Name = uniqueFileName,
                    AnimalId = animal.Id
                };

                this.data.Images.Add(animalImageData);
                animal.AnimalImages.Add(animalImageData);

            }

            this.data.Animals.Add(animal);
            this.data.SaveChanges();

            return animal.Id;
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
