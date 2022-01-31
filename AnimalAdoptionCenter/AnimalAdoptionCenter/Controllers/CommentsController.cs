using AnimalAdoptionCenter.Infrastructure;
using AnimalAdoptionCenter.Models.Comments;
using AnimalAdoptionCenter.Services.Comments;
using AnimalAdoptionCenter.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Controllers
{
    public class CommentsController : Controller
    {

        private readonly ICommentsService comments;
        private readonly IUserService users;


        public CommentsController(ICommentsService comments, IUserService users)
        {
            this.comments = comments;
            this.users = users;
        }
        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCommentFormModel model,  int newsId)
        {
            var userId = this.users.IdUser(this.User.Id());
            var username = this.users.Username(this.User.Id());

            if (userId == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            this.comments.Add(
                model.Content,
                newsId,
                model.UserId,
                username
                );

            return RedirectToAction("Details", "News", new { newsId = newsId });
        }

        public IActionResult All()
        {
            var comments = this.comments.All();
            return View(comments);
        }

        public IActionResult Delete(int id, int newsId)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Unauthorized();
            }

            this.comments.Delete(id);
            return RedirectToAction("Details", "News", new {newsId});
        }
    }
}
