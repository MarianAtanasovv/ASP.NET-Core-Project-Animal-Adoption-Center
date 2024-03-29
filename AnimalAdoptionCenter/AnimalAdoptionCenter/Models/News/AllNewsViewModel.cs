﻿using AnimalAdoptionCenter.Data.Models;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Models
{
    public class AllNewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string DateTime { get; set; }

        public List<NewsImage> NewsImages { get; set; }


    }
}
