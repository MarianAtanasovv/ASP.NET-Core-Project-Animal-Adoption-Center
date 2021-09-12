using AnimalAdoptionCenter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Models.Adoption
{
    using static DataConstants;

    public class AdoptionInterviewFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(AdopterNameMaxLength, MinimumLength = AdopterNameMinLength, ErrorMessage = "Name should be between {2} and {1} characters long.")]

        public string Name { get; set; }

        [Required]
        [StringLength(AdopterHomeInformationMaxLength, MinimumLength = AdopterHomeInformationMinLength, ErrorMessage = "Home information should be between {2} and {1} characters long.")]

        public string HomeInformation { get; set; }

        [Required]
        public bool OwnHome { get; set; }

        [Required]
        public int HoursAlone { get; set; }

        [Required]
        [StringLength(AdopterAllergiesInFamilyMaxLength, MinimumLength = AdopterAllergiesInFamilyMinLength, ErrorMessage = "Allergies information should be between {2} and {1} characters long.")]

        public string AllergiesInFamily { get; set; }

        [Required]
        [StringLength(AdopterBreedExplanationMaxLength, MinimumLength = AdopterBreedExplanationMinLength, ErrorMessage = "Breed information should be between {2} and {1} characters long.")]

        public string BreedExplanation { get; set; }

        [Required]
        [MaxLength(EnclosureMaxLenght)]
        public string Enclosure { get; set; }

        [Required]
        [StringLength(VetKnowledgeMaxLength, MinimumLength = VetKnowledgeMinLength, ErrorMessage = "Vet knowledge should be between {2} and {1} characters long.")]

        public string VetKnowledge { get; set; }
    }
}
