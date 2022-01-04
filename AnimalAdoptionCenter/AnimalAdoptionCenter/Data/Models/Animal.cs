using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Data.Models
{
    using static DataConstants;
    public class Animal
    {   public Animal()
        {
            this.AnimalImages = new List<AnimalImage>();
            this.AdoptedDogs = new List<Animal>();
            this.PotentialAdopters = new List<PotentialAdopter>();
        }

        public int Id { get; set; }

        [Required]
        public List<AnimalImage> AnimalImages { get; set; } 

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
        [MaxLength(AnimalDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool Aggressive { get; set; }

        [Required]
        public bool Neutered { get; set; }
        public bool Vaccinated { get; set; }


        public List<PotentialAdopter> PotentialAdopters { get; set; }

        public List<AdoptionInterview> AdoptionInterviews { get; set; }

        public List<Animal> AdoptedDogs { get; set; }

    }
}
