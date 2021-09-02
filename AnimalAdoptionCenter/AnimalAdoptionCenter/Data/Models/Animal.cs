using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Data.Models
{
    using static DataConstants;
    public class Animal
    {   public Animal()
        {
            this.AnimalImages = new List<Image>();
        }

        public int Id { get; set; }

        [Required]
        public List<Image> AnimalImages { get; set; } 

        [Required]
        [MaxLength(AnimalNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(AnimalAgeMin, AnimalAgeMax)]
        public int Age { get; set; }

        [Required]
        [MaxLength(AnimalBreedMaxLength)]
        public string Breed { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool Agressive { get; set; }
    }
}
