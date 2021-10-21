using AnimalAdoptionCenter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoptionCenter.Services
{
    public interface IEventService
    {
        public int Add(AddEventFormModel model);
        public bool checkHour(string hour, string date);
        public StringBuilder FreeHours(string date);
    }

 
}
