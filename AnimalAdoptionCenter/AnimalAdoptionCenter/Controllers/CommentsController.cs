using AnimalAdoptionCenter.Infrastructure;
using AnimalAdoptionCenter.Services.Comments;
using AnimalAdoptionCenter.Services.Users;
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
        public IActionResult Add(string content, int newsId)
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

            this.comments.Add(content,
                newsId,
                userId,
                username
                );

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All()
        {
            var comments = this.comments.All();
            return View(comments);
        }
    }
}
