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

        public IEnumerable<AllNewsViewModel> All()
        {
            var news =  this.data.News.Select(x => new AllNewsViewModel
            {
                Id = x.Id,
                Body = x.Body,
                Title = x.Title,
                DateTime = x.PublishedOn,
                NewsImages = x.NewsImages
            }).ToList();

            return news;
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
