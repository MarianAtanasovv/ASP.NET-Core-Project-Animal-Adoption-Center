using AnimalAdoptionCenter.Data;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Services.Event
{
    using static DataConstants;

    public class AllAppointmentsViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MaxLength(EventDescriptonMaxLength)]
        public string Description { get; set; }

        [Required]
        public string StartHour { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
