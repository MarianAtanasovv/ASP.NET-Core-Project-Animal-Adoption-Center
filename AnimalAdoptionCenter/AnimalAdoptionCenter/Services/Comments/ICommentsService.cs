using AnimalAdoptionCenter.Models.Comments;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Services.Comments
{
    public interface ICommentsService
    {
        public bool Delete(int id);

        public IEnumerable<AllCommentsViewModel> All();

        int Add(
        
        string content,
        int newsId,
        string userId,
        string username);
    }
}
