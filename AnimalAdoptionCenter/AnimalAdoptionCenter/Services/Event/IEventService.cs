using AnimalAdoptionCenter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AnimalAdoptionCenter.Services.Event;

namespace AnimalAdoptionCenter.Services
{
    public interface IEventService
    {
        public int Add(AddEventFormModel model);
        public bool CheckHour(string hour, string date);
        public StringBuilder FreeHours(string date);

        public IEnumerable<AllAppointmentsViewModel> All();
    }

 
}
