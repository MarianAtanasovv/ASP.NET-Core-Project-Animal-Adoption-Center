using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Areas.Administration.Controllers
{
    public class NewsController : AdministrationController
    {
        private readonly INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddNewsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.news.Add(model);

            return RedirectToAction("All", "News", new { area = "" });

        }

        [Authorize]
        public IActionResult Delete(int newsId)
        {
            this.news.Delete(newsId);

            return RedirectToAction("All", "News", new {area = ""});
        }
    }
}
