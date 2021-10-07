using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Models.News;
using System;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Services
{
    public interface INewsService 
    {
        public int Add(
            string title,
            string body,
            DateTime dateTime);

        public IEnumerable<AllNewsViewModel> All();

        public NewsDetailsViewModel Details(int newsId);
    }
}
