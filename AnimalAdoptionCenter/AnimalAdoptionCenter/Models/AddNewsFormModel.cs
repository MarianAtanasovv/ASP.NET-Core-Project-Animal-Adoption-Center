using AnimalAdoptionCenter.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Models
{
    using static DataConstants;

    public class AddNewsFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NewsTitleMaxLength, MinimumLength = NewsTitleMinLength, ErrorMessage = "Title should be between {2} and {1} characters long.")]
        public string Title { get; set; }

        [Required]
        [StringLength(NewsBodyMaxLength, MinimumLength = NewsBodyMinLength, ErrorMessage = "News body should be between {2} and {1} characters long.")]
        public string Body { get; set; }

        [Required]
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
