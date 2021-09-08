using AnimalAdoptionCenter.Data;
using Microsoft.EntityFrameworkCore;
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
                Description = x.Description,
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
