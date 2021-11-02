using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Controllers
{
    public class EventController : Controller
    {

        private readonly IEventService eventData;

        public EventController(IEventService eventData)
        {
            this.eventData = eventData;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
     
        [HttpPost]
        public IActionResult Add(AddEventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            
            if(this.eventData.checkHour(model.StartHour, model.Date) == false)
            {
                TempData["someWarning"] = eventData.FreeHours(model.Date);
                return View(model);
            }

            this.eventData.Add(model);

            return RedirectToAction("Index", "Home");
        }
     
    }
}
