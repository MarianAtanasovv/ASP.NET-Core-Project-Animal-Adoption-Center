using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models.Animal;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class DogService : IDogService
    {
        private readonly ApplicationDbContext data;
       
        public DogService(ApplicationDbContext data)
        {
            this.data = data;
           
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
                Agressive = x.Agressive,
                Color = x.Color,
                Images = x.AnimalImages,
                Health = x.Health
                
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
               Agressive = g.Agressive.ToString(),
               Breed = g.Breed,
               Color = g.Color,
               Gender = g.Gender.ToString(),
               Health = g.Health
              
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
    }

}
