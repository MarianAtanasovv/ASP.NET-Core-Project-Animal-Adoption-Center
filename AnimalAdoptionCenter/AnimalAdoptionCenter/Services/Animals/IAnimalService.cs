using AnimalAdoptionCenter.Models.Animal;
using AnimalAdoptionCenter.Models.Animals;
using AnimalAdoptionCenter.Services.Animals;
using System.Collections.Generic;

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


    }
}
