using AnimalAdoptionCenter.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Models.Comments
{
    public class AddCommentFormModel
    {

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        
        public string Username { get; set; }

        public Data.News News { get; set; }

        public int NewsId { get; set; }

        public string CreatedOn { get; set; } = DateTime.UtcNow.ToShortDateString();

        public string UserId { get; set; }
    }
}
