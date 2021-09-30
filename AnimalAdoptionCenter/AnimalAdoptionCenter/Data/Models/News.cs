using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Data.Models
{
    using static DataConstants;

    public class News
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NewsTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(NewsBodyMaxLength)]
        public string Body { get; set; }

        [Required]
        public string PublishedOn { get; set; }
    }
}
