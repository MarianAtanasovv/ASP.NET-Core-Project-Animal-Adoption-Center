using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public bool checkHour(string hour, string date)
        {
            var checkForDate = this.data.Events.Any(x => x.StartHour == hour && x.Date == date);
            FreeHours(date);

            if (checkForDate)
            {
                return false;
            }
            return true;
        }

        public StringBuilder FreeHours(string date)
        {
            var takenHours = this.data.Events.Where(x => x.Date == date).Select(x => x.StartHour).ToList();
            var workingHours = new List<string>()
            {
               "10:00", "11:00","12:00", "13:00","14:00", "15:00","16:00", "17:00",
            };

            var freeHours = workingHours.Except(takenHours);

            var sb = new StringBuilder();
            sb.AppendLine("This hour is reserved!");
            sb.AppendLine("Free hours:");
            foreach (var item in freeHours)
            {
                sb.AppendLine(item + ", ");
            }
            return sb;
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
                EndHour = model.StartHour

            };

           


            this.data.Events.Add(eventData);
            this.data.SaveChanges();

            return eventData.Id;

        }
    }
}
