using AnimalAdoptionCenter.Models;

namespace AnimalAdoptionCenter.Services
{
    public interface IEventService
    {
        public int Add(AddEventFormModel model);
    }
}
