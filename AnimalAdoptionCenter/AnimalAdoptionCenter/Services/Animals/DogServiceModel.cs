using AnimalAdoptionCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class DogServiceModel
    {
        public int Id { get; set; }

        public List<Image> AnimalImages { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public string Gender { get; set; }

        public string Agressive { get; set; }

        public string Health { get; set; }
    }
}
