using System.Collections.Generic;

namespace AnimalAdoptionCenter.Services
{
    public class NewsQueryModel
    {
        public int CurrentPage { get; set; }

        public int NewsPerPage { get; set; }

        public int TotalNews { get; set; }

        public IEnumerable<NewsServiceModel> News { get; set; }
    }
}
