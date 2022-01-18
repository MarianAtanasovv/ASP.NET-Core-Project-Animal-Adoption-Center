using AnimalAdoptionCenter.Models.Animal;
using AnimalAdoptionCenter.Models.Animals;
using AnimalAdoptionCenter.Services.Animals;
using System.Collections.Generic;
using AnimalAdoptionCenter.Data.Models;
using Microsoft.AspNetCore.Http;

namespace AnimalAdoptionCenter.Services
{
    public interface IAnimalService
    {
        AnimalDetailsServiceModel Details(int id);
        public AnimalQueryModel All(
                 string searchTerm,
                 AnimalSorting sorting,
                 int currentPage,
                 int animalsPerPage,
                 string name);

        public IEnumerable<string> AllAnimals();

        public int Remove(int id);

        public int Add(AddAnimalFormModel animalModel);

        public bool Edit(int id,
            string name,
            int age,
            bool aggressive,
            string description,
            bool neutered, 
            bool vaccinated,
            string breed,
            Gender gender, 
            string color
        );
    }
}
