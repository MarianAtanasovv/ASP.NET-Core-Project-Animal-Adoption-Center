using AnimalAdoptionCenter.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Models
{
    using static DataConstants;

    public class AddEventFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength, ErrorMessage = "Name must be between {2} and {1} characters long.")]

        public string FullName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(EventDescriptonMaxLength, MinimumLength = EventDescriptionMinLenght, ErrorMessage = "Description must be between {2} and {1} characters long.")]
        public string Description { get; set; }

        [Required]
        public string StartHour { get; set; }
        //[Required]
        //public DateTime EndHour { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
