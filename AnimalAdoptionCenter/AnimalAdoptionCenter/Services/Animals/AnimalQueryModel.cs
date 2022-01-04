using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class AnimalQueryModel
    {
        public int CurrentPage { get; set; }

        public int AnimalsPerPage { get; set; }

        public int TotalAnimals { get; set; }

        public IEnumerable<AnimalServiceModel> Animals { get; set; }
    }
}
