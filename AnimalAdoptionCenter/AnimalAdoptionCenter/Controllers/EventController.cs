﻿using AnimalAdoptionCenter.Models;
using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Event;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]

        public IActionResult Add(AddEventFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            if (this.eventData.CheckHour(model.StartHour, model.Date) == false)
            {
                TempData["someWarning"] = eventData.FreeHours(model.Date);
                return View(model);
            }

            this.eventData.Add(model);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult All(AllAppointmentsViewModel model)
        {
            var appointments = this.eventData.All();

            return View(appointments);
        }

    }
}
