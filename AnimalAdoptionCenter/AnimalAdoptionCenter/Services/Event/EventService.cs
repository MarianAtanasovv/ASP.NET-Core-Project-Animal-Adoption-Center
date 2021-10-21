using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Linq;
using System.Web.WebPages.Html;

namespace AnimalAdoptionCenter.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext data;
       
        public EventService(ApplicationDbContext data)
        {
            this.data = data;
            
        }
        public bool checkHour(DateTime hour, DateTime date)
        {
            var checkForDate = this.data.Events.Any(x => x.StartHour == hour && x.Date == date);

            if (checkForDate)
            {
                return false;
            }
            return true;
        }
        
        public int Add(AddEventFormModel model)
        {
            

            var eventData = new Event
            {
                FullName = model.FullName,
                Phone = model.PhoneNumber,
                Description = model.Description,
                Date = model.Date,
                StartHour = model.StartHour,
                EndHour = model.StartHour.AddHours(1)

            };

           


            this.data.Events.Add(eventData);
            this.data.SaveChanges();

            return eventData.Id;

        }
    }
}
