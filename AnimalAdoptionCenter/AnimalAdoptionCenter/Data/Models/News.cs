using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Dаta;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Data
{
    using static DataConstants;

    public class News
    {
        public News()
        {
            this.NewsImages = new List<NewsImage>();
            this.Comments = new List<Comment>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(NewsTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public List<NewsImage> NewsImages { get; set; }

        [Required]
        [MaxLength(NewsBodyMaxLength)]
        public string Body { get; set; }

        [Required]
        public string PublishedOn { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
