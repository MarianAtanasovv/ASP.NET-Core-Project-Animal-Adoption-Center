using AnimalAdoptionCenter.Services.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services.Adoption
{
    public interface IAdoptionService
    {
        public int Add(
            string name,
            string homeInformation,
            bool ownHome,
            int hoursAlone,
            string allergiesFamily,
            string breedExplanation,
            string enclosure,
            string vetKnowledge,
            int dogId,
            string userId);

        public IList<AnimalAdoptionInterviewsReviews> Review(int id);

        public int Approve(int dogId);

        public void Disapprove(int dogId);
    }
}
