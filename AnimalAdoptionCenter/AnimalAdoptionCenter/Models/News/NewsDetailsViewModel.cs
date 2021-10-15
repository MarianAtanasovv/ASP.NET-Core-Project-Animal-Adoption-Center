using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Dаta;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Models
{
    public class NewsDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public string PublishedOn { get; set; }
        public List<NewsImage> NewsImages { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
