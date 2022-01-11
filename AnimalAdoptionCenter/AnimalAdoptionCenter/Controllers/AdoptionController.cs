using AnimalAdoptionCenter.Infrastructure;
using AnimalAdoptionCenter.Models.Adoption;
using AnimalAdoptionCenter.Services.Adoption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly IAdoptionService interview;

        public AdoptionController(IAdoptionService interview)
        {
            this.interview = interview;
        }

        [HttpGet]
        public IActionResult Interview()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Interview(AdoptionInterviewFormModel interviewModel, int dogId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string userId = User.Id();
            this.interview.Add(
                interviewModel.Name,
                interviewModel.HomeInformation,
                interviewModel.OwnHome,
                interviewModel.HoursAlone,
                interviewModel.AllergiesInFamily,
                interviewModel.BreedExplanation,
                interviewModel.Enclosure,
                interviewModel.VetKnowledge,
                dogId,
                userId);
            return RedirectToAction("ThankYou", "Adoption");
            
        }

        [HttpGet]
        public IActionResult Review(int dogId)
        {
            var interview = this.interview.Review(dogId);

            return View(interview);
        }

        [HttpGet]
        public IActionResult Approve(int dogId)
        {

            var approved = this.interview.Approve(dogId);
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Disapprove(int dogId)
        {

            this.interview.Disapprove(dogId);
            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
