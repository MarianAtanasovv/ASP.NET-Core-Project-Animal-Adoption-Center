using AnimalAdoptionCenter.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Models.NewsCommentsModel
{
    public class NewsCommentsModel
    {
        public NewsDetailsViewModel NewsDetailsViewModel { get; set; }

        public AddCommentFormModel AddCommentFormModel { get; set; }

        public IEnumerable<AllCommentsViewModel> AllCommentsViewModel { get; set; }

    }
}
