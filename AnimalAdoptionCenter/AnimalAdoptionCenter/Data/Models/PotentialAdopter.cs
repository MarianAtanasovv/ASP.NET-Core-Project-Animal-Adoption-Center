using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Data.Models
{
    public class PotentialAdopter
    {
        [Key]
        public string Id { get; set; }

        public int DogId { get; set; }

        public Animal Dog { get; set; }
    }
}
