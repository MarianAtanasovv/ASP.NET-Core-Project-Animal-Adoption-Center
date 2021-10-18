using AnimalAdoptionCenter.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoptionCenter.Models 
{
    public class AllNewsQueryModel
    {

        public const int NewsPerPage = 6;

        public string Name { get; set; }

        [Display(Name = "Search")]
        public string SearchTerm { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalNews { get; set; }

        public IEnumerable<string> Names { get; set; }

        public IEnumerable<NewsServiceModel> News { get; set; }
    }
}
