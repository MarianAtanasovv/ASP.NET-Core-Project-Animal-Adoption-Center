using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Data.Models
{
    using static DataConstants;
    public class PetCareArticle
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ArticleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ArticleBodyMaxLength)]
        public string Body { get; set; }
    }
}
