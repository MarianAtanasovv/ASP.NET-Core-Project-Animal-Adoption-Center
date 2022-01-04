using AnimalAdoptionCenter.Services.Animals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Models.Animal
{
    public class AllAnimalsQueryModel
    {

        public const int AnimalsPerPage = 6;

        public string Name { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalAnimals { get; set; }

        public AnimalSorting Sorting { get; init; }

        public IEnumerable<string> Names { get; set; }

        public IEnumerable<AnimalServiceModel> Animals { get; set; }
    }
}
