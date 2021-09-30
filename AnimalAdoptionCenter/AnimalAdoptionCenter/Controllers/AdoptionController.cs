using AnimalAdoptionCenter.Models.Adoption;
using AnimalAdoptionCenter.Services.Adoption;
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
        public IActionResult Interview(AdoptionInterviewFormModel interviewModel, int dogId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.interview.Add(
                interviewModel.Name,
                interviewModel.HomeInformation,
                interviewModel.OwnHome,
                interviewModel.HoursAlone,
                interviewModel.AllergiesInFamily,
                interviewModel.BreedExplanation,
                interviewModel.Enclosure,
                interviewModel.VetKnowledge,
                dogId);

            return RedirectToAction("Index", "Home");
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

            return RedirectToAction("ThankYou", "Adoption");
        }

        [HttpGet]
        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
