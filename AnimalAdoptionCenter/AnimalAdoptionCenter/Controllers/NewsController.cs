using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Models.Comments;
using AnimalAdoptionCenter.Models.NewsCommentsModel;
using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Comments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService news;
        private readonly ICommentsService comments;


        public NewsController(INewsService news, ICommentsService comments)
        {
            this.news = news;
            this.comments = comments;
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

            this.news.Add(model);

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



            var commentsData = new AddCommentFormModel();
            var newsData = details;
            var comments = this.comments.All();
            var model = new NewsCommentsModel
            {
                AddCommentFormModel = commentsData,
                NewsDetailsViewModel = newsData,
                AllCommentsViewModel = comments
            };

            return View(model);
        }

    }
}
