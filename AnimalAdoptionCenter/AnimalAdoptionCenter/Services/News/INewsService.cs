using AnimalAdoptionCenter.Models;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Services
{
    public interface INewsService 
    {
        public int Add(AddNewsFormModel model);

        public NewsQueryModel All(
               string searchTerm,
               int currentPage,
               int newsPerPage,
               string name);

        public NewsDetailsViewModel Details(int newsId);
        public int Delete(int newsId);
        public IEnumerable<string> AllNews();

        public bool Edit(int id,
            string title,
            string body);
    }
}
