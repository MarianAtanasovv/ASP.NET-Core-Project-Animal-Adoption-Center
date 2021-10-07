using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Models.News;
using AnimalAdoptionCenter.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalAdoptionCenter
{
    
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext data;
        public NewsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int Add(string title, string body, DateTime dateTime)
        {
            var news = new News
            {
                Title = title,
                Body = body,
                PublishedOn = dateTime.ToString()

            };

            this.data.News.Add(news);
            this.data.SaveChanges();

            return news.Id;
        }

        public IEnumerable<AllNewsViewModel> All()
        {
            var news =  this.data.News.Select(x => new AllNewsViewModel
            {
                Id = x.Id,
                Body = x.Body,
                Title = x.Title,
                DateTime = x.PublishedOn
            }).ToList();

            return news;
        }

        public NewsDetailsViewModel Details(int newsId)
        {
            var details = this.data.News.Where(x => x.Id == newsId)
           .Select(d => new NewsDetailsViewModel
           {
               Id = d.Id,
               Title = d.Title,
               Body = d.Body,
               PublishedOn = d.PublishedOn
           })
            .FirstOrDefault();

            return details;
        }
    }
}
