using AnimalAdoptionCenter.Services.Animals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Models.Animal
{
    public class AllDogsQueryModel
    {

        public const int DogsPerPage = 6;

        public string Name { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalDogs { get; set; }

        public AnimalSorting Sorting { get; init; }

        public IEnumerable<string> Names { get; set; }

        public IEnumerable<DogServiceModel> Dogs { get; set; }
    }
}
