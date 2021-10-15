using AnimalAdoptionCenter.Data;
using AnimalAdoptionCenter.Dаta;
using AnimalAdoptionCenter.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalAdoptionCenter.Services.Comments
{
    public class CommentService : ICommentsService
    {
        private readonly ApplicationDbContext data;

        public CommentService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public int Add(string content, int newsId, string userId, string username)
        {
            var comment = new Comment
            {
                Content = content,
                CreatedOn = DateTime.UtcNow.ToString("r"),
                NewsId = newsId,
                UserId = userId,
                Username =  username

            };

            this.data.Comments.Add(comment);
            this.data.SaveChanges();

            return comment.Id;
        }

        public IEnumerable<AllCommentsViewModel> All()
        {
            var comments = this.data.Comments.Select(x => new AllCommentsViewModel
            {
                Name = x.Username,
                Comment = x.Content,
                PublishedOn = x.CreatedOn
            }).ToList();

            return comments;
        }
    }
}
