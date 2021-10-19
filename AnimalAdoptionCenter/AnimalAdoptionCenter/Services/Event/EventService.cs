using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Models;
using System.Linq;

namespace AnimalAdoptionCenter.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext data;

        public EventService(ApplicationDbContext data)
        {
            this.data = data;
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
                EndHour = model.EndHour

            };



            this.data.Events.Add(eventData);
            this.data.SaveChanges();

            return eventData.Id;

        }
    }
}
