using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Models.News;
using AnimalAdoptionCenter.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddNewsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.news.Add(model.Title,
                model.Body,
                model.DateTime);

            return RedirectToAction("Home", "Index");

            
        }

        [HttpGet]
        public IActionResult All()
        {

            var news = this.news.All();
            return View(news);

        }

        [HttpGet]
        public IActionResult Details(int newsId)
        {
            var details = this.news.Details(newsId);

            if (details == null)
            {
                return NotFound();
            }


            return View(new NewsDetailsViewModel
            {
                Id = details.Id,
                Title = details.Title,
                Body = details.Body,
                PublishedOn = details.PublishedOn


            });
        }

    }
}
