using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Data.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int AnimalId { get; set; }

        public Dog Animal { get; set; }
    }
}
