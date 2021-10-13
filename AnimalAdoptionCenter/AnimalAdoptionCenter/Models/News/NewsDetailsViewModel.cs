using AnimalAdoptionCenter.Data.Models;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Models.News
{
    public class NewsDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public string PublishedOn { get; set; }
        public List<NewsImage> NewsImages { get; set; }

    }
}
