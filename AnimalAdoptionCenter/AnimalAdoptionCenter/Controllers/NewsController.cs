using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Models.Comments;
using AnimalAdoptionCenter.Models.NewsCommentsModel;
using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Comments;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult All([FromQuery] AllNewsQueryModel query)
        {
            
            var newsQueryResult = this.news.All(
               query.SearchTerm,
               query.CurrentPage,
               AllNewsQueryModel.NewsPerPage,
               query.Name);

            var newsTitles = this.news.AllNews();

            query.TotalNews = newsQueryResult.TotalNews;
            query.News = newsQueryResult.News;
            query.Names = newsTitles;

            return this.View(query);

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
