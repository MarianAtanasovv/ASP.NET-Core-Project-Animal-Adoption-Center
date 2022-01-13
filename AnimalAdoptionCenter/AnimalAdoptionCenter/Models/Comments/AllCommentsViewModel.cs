using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Models.Comments
{
    public class AllCommentsViewModel
    {
        public int Id { get; init; }
        public string Name { get; set; }

        public string Comment { get; set; }

        public string PublishedOn { get; set; }

        
    }
}
