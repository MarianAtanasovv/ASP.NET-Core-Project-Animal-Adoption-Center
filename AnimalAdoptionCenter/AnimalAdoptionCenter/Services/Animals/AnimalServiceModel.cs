using AnimalAdoptionCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class AnimalServiceModel : IAnimalModel
    {
        public int Id { get; set; }

        public List<AnimalImage> AnimalImages { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public string Gender { get; set; }

        public bool Aggressive { get; set; }

        public bool Neutered { get; set; }

        public bool Vaccinated { get; set; }

    }
}
