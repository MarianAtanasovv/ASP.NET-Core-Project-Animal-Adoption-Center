using AnimalAdoptionCenter.Models.Animal;
using AnimalAdoptionCenter.Services.Animals;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Services
{
    public interface IDogService
    {
        DogDetailsServiceModel Details(int id);
        public DogsQueryModel All(
                 string searchTerm,
                 AnimalSorting sorting,
                 int currentPage,
                 int dogsPerPage,
                 string name);

        public IEnumerable<string> AllDogs();
    }
}
