using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Services;
using Microsoft.AspNetCore.Mvc;

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

    }
}
