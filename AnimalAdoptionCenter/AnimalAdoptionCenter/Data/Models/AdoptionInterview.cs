using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Data.Models
{
    using static DataConstants;

    public class AdoptionInterview
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AdopterNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(AdopterHomeInformationMaxLength)]
        public string HomeInformation { get; set; }

        [Required]
        public bool OwnHome { get; set; }

        [Required]
        public int HoursAlone { get; set; }

        [Required]
        [MaxLength(AdopterAllergiesInFamilyMaxLength)]
        public string AllergiesInFamily { get; set; }

        [Required]
        [MaxLength(AdopterBreedExplanationMaxLength)]
        public string BreedExplanation { get; set; }

        [Required]
        [MaxLength(EnclosureMaxLenght)]
        public string Enclosure { get; set; }

        [Required]
        [MaxLength(VetKnowledgeMaxLength)]
        public string VetKnowledge { get; set; }


        public string UserId { get; set; }

        public Animal Animal { get; set; }

        public int AnimalId { get; set; }
    }
}
