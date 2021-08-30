using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Models.Animals
{
    using static DataConstants;

    public class AddAnimalFormModel
    {
        public int Id { get; set; }

        [Required]
        public IFormFileCollection Images { get; set; }

        [Required]
        [StringLength(AnimalNameMaxLength, MinimumLength = AnimalNameMinLength, ErrorMessage = "Name should be between {2} and {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [Range(AnimalAgeMin, AnimalAgeMax, ErrorMessage = "Age should be between {2} and {1} years.")]
        public int Age { get; set; }

        [Required]
        [StringLength(AnimalBreedMaxLength, MinimumLength = AnimalBreedMinLength, ErrorMessage = "Breed should be between {2} and {1} characters long.")]
        public string Breed { get; set; }

        [Required]
        public Data.Models.Type Type { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool Agressive { get; set; }
    }
}
