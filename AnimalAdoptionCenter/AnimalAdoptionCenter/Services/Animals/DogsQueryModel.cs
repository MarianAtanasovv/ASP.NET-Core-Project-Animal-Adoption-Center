using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class DogsQueryModel
    {
        public int CurrentPage { get; set; }

        public int DogsPerPage { get; set; }

        public int TotalDogs { get; set; }

        public IEnumerable<DogServiceModel> Dogs { get; set; }
    }
}
