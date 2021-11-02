using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services.Animals
{
    public class DogAdoptionInterviewsReviews
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string HomeInformation { get; set; }

        public int HoursAlone { get; set; }

        public bool OwnHome { get; set; }

        public string AllergiesInFamily { get; set; }

        public string BreedExplanation { get; set; }

        public string VetKnowledge { get; set; }


        public string Enclosure { get; set; }

        public int DogId { get; set; }

    }
}
