using AnimalAdoptionCenter.Models;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Services
{
    public interface INewsService 
    {
        public int Add(AddNewsFormModel model);

        //public IEnumerable<AllNewsViewModel> All(AllNewsViewModel model);

        public NewsQueryModel All(
               string searchTerm,
               int currentPage,
               int newsPerPage,
               string name);

        public NewsDetailsViewModel Details(int newsId);

        public IEnumerable<string> AllNews();
    }
}
