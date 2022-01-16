using AnimalAdoptionCenter.Services;
using AnimalAdoptionCenter.Services.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Areas.Vet.Controllers
{
    public class AppointmentController : VetController
    {
        private readonly IAppointmentService eventData;

        public AppointmentController(IAppointmentService eventData)
        {
            this.eventData = eventData;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All(AllAppointmentsViewModel model)
        {
            var appointments = this.eventData.All();

            return View(appointments);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            this.eventData.Delete(id);

            return RedirectToAction("All", "Appointment", new { area = "Vet" });
        }
    }
}
