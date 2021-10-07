using AnimalAdoptionCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Models
{
    public class AllNewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string DateTime { get; set; } 

        public IList<News> News { get; set; }

    }
}
