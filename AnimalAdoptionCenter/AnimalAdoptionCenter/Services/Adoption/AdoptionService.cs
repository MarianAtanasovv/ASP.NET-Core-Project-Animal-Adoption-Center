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
            int animalId
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
                AnimalId = animalId

            };

            this.data.AdoptionInterviews.Add(interview);
            this.data.SaveChanges();

            return interview.Id;
        }

        public int Approve(int dogId)
        {
            var animal = this.data.Animals.Where(x => x.Id == dogId).FirstOrDefault();

            this.data.Remove(animal);
            this.data.SaveChanges();

            return animal.Id;
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
                 }
                 )
                 .ToList();

        }
    }
}
