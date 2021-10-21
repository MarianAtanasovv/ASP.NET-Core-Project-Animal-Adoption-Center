using AnimalAdoptionCenter.Models;
using System;

namespace AnimalAdoptionCenter.Services
{
    public interface IEventService
    {
        public int Add(AddEventFormModel model);
        public bool checkHour(DateTime hour, DateTime date);
    }
}
