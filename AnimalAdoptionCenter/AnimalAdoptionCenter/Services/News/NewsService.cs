using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnimalAdoptionCenter
{

    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext data;
        private readonly IWebHostEnvironment webHostEnvironment;
        public NewsService(ApplicationDbContext data, IWebHostEnvironment webHostEnvironment)
        {
            this.data = data;
            this.webHostEnvironment = webHostEnvironment;
        }

        public int Add(AddNewsFormModel model)
        {
            var news = new News
            {
                Title = model.Title,
                Body = model.Body,
                PublishedOn = model.DateTime.ToString()
                
            };

            foreach (var image in model.Images)
            {
                var uniqueFileName = UploadedFile(image);
                var newsImageData = new NewsImage
                {
                    Name = uniqueFileName,
                    NewsId = news.Id
                };

                this.data.NewsImages.Add(newsImageData);
                news.NewsImages.Add(newsImageData);

            }

            this.data.News.Add(news);
            this.data.SaveChanges();

            return news.Id;
        }

        public IEnumerable<AllNewsViewModel> All(AllNewsViewModel model)
        {
            var news =  this.data.News.Select(x => new AllNewsViewModel
            {
                Id = model.Id,
                Body = model.Body,
                Title = model.Title,
                DateTime = model.DateTime,
                NewsImages = model.NewsImages
            }).ToList();

            return news;
        }

        public NewsQueryModel All(
          string searchTerm,
          int currentPage,
          int newsPerPage,
          string name)
        {
            var newsQuery = this.data.News.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                newsQuery = newsQuery.Where(x => x.Title == name);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                newsQuery = newsQuery.Where(x => x.Title.ToLower().Contains(searchTerm.ToLower()));
            }

         

            var totalNews = newsQuery.Count();

            var news = GetNews(newsQuery
                .Skip((currentPage - 1) * newsPerPage)
                .Take(newsPerPage));


            return new NewsQueryModel
            {
                TotalNews = totalNews,
                News = news,
                CurrentPage = currentPage,
                NewsPerPage = newsPerPage
            };

        }

        private static IEnumerable<NewsServiceModel> GetNews(IQueryable<News> newsQuery)
        {
            return newsQuery
           .Select(g => new NewsServiceModel
           {
               Id = g.Id,
               Title = g.Title,
               Body = g.Body,
               PublishedOn = g.PublishedOn,
               Comments = g.Comments,
               NewsImages = g.NewsImages,


           })
           .ToList();
        }

            public NewsDetailsViewModel Details(int newsId)
            {
                var details = this.data.News.Where(x => x.Id == newsId)
           .Select(x => new NewsDetailsViewModel
            {
               Id = x.Id,
               Title = x.Title,
               Body = x.Body,
               PublishedOn = x.PublishedOn,
               NewsImages = x.NewsImages,
               Comments = x.Comments

            })
            .FirstOrDefault();

            return details;
        }

            public int Delete(int newsId)
            {
                var newsToDelete = this.data.News.Single(x => x.Id == newsId);
                this.data.Remove(newsToDelete);
                this.data.SaveChanges();

                return newsToDelete.Id;
            }

            public IEnumerable<string> AllNews()
        {
            return this.data
                .News
                .Select(x => x.Title)
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

            public bool Edit(int id, 
                string title, 
                string body)
            {
                var newsData = this.data.News.Find(id);
                if (newsData == null)
                {
                    return false;
                }

                newsData.Title = title;
                newsData.Body = body;

                this.data.SaveChanges();

                return true;
            }

            private string UploadedFile(IFormFile imageData)
        {
            string uniqueFileName = null;

            if (imageData != null)
            {
                var uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "databaseFiles/News");
                uniqueFileName = Guid.NewGuid() + "_" + imageData.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                imageData.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}
