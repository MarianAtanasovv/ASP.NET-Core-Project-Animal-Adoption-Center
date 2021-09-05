using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models.Animals;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        private readonly ApplicationDbContext data;
       
        public AnimalService(ApplicationDbContext data)
        {
            this.data = data;
           
        }

        public AnimalDetailsServiceModel Details(int id)
        {
            var details = this.data.Animals.Include(x => x.AnimalImages).Where(x => x.Id == id)
            .Select(x => new AnimalDetailsServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Breed = x.Breed,
                Age = x.Age,
                Gender = x.Gender,
                Type = x.Type,
                Agressive = x.Agressive,
                Color = x.Color,
                Images = x.AnimalImages
                
            })
              .FirstOrDefault();

            return details;
        }

       
    }

}
