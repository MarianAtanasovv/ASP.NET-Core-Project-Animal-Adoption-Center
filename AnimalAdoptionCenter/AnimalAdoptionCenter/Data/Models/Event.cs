using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Data.Models
{
    using static DataConstants;

    public class Event
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
        public DateTime StartHour { get; set; }

        [Required]
        public DateTime EndHour { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ICollection<ReservedHours> ReservedHours { get; set; }

        
    }
}
