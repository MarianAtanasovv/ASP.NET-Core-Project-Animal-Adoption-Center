using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Dаta;
using System.Collections.Generic;
using AnimalAdoptionCenter.Services.News;

namespace AnimalAdoptionCenter.Services
{
    public class NewsServiceModel : INewsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<NewsImage> NewsImages { get; set; }

        public string Body { get; set; }

        public string PublishedOn { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
