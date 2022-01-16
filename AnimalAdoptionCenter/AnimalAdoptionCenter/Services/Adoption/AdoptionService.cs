using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Services.Animals;
using System.Collections.Generic;
using System.Linq;

namespace AnimalAdoptionCenter.Services.Adoption
{
    public class AdoptionService : IAdoptionService
    {

        private readonly ApplicationDbContext data;

        public AdoptionService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int Add(
            string name,
            string homeInformation,
            bool ownHome, 
            int hoursAlone, 
            string allergiesFamily, 
            string breedExplanation, 
            string enclosure,
            string vetKnowledge,
            int animalId,
            string userId
        )
        {
            var interview = new AdoptionInterview()
            {

                Name = name,
                HomeInformation = homeInformation,
                HoursAlone = hoursAlone,
                OwnHome = ownHome,
                AllergiesInFamily = allergiesFamily,
                BreedExplanation = breedExplanation,
                VetKnowledge = vetKnowledge,
                Enclosure = enclosure,
                AnimalId = animalId,
                UserId = userId


            };

            this.data.AdoptionInterviews.Add(interview);
            this.data.SaveChanges();

            return interview.Id;
        }

        public int Approve(int dogId)
        {
            var animal = this.data.Animals.Single(x => x.Id == dogId);

            this.data.Remove(animal);
            this.data.SaveChanges();

            return animal.Id;
        }
        public void Disapprove(int dogId)
        {
            var interview = this.data.AdoptionInterviews.Single(x => x.AnimalId == dogId);
            var removeInterview = this.data.AdoptionInterviews.Remove(interview);
            this.data.SaveChanges();

        }

        public IList<AnimalAdoptionInterviewsReviews> Review(int animalId)
        {
            return this.data.AdoptionInterviews
                 .Where(x => x.AnimalId == animalId)
                 .Select(x => new AnimalAdoptionInterviewsReviews
                 {
                     Id = animalId,
                     Name = x.Name,
                     AllergiesInFamily = x.AllergiesInFamily,
                     BreedExplanation = x.BreedExplanation,
                     Enclosure = x.Enclosure,
                     HomeInformation = x.HomeInformation,
                     HoursAlone = x.HoursAlone,
                     OwnHome = x.OwnHome,
                     VetKnowledge = x.VetKnowledge,
                     UserId = x.UserId
                 }
                 )
                 .ToList();

        }

        
    }
}
