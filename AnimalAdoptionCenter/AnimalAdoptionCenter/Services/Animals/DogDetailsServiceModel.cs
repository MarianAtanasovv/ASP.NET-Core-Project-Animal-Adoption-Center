using AnimalAdoptionCenter.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class DogDetailsServiceModel
    {
        public int Id { get; set; }

        [Required]
        public List<Image> Images { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool Agressive { get; set; }

        [Required]
        public string Health { get; set; }
    }
}
