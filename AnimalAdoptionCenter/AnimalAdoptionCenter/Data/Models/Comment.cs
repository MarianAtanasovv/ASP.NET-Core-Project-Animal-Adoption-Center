using AnimalAdoptionCenter.Data;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Dаta
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Username { get; set; }

        public News News { get; set; }

        public int NewsId { get; set; }

        public string CreatedOn { get; set; }

        public string UserId { get; set; }
    }
}
