using AnimalAdoptionCenter.Models.Animal;
using AnimalAdoptionCenter.Models.Animals;
using AnimalAdoptionCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AnimalAdoptionCenter.Areas.Administration.Controllers
{

    public class AnimalsController : AdministrationController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAnimalService animal;
        public AnimalsController(IWebHostEnvironment hostEnvironment, IAnimalService animal)
        {
            this.webHostEnvironment = hostEnvironment;
            this.animal = animal;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Add(AddAnimalFormModel animalModel)
        {

            if (!ModelState.IsValid)
            {
                return View(animalModel);
            }

            this.animal.Add(animalModel);


            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Remove(int id)
        {
            var dog = this.animal.Remove(id);

            if (dog == 0)
            {
                return NotFound();
            }

            return RedirectToAction("All", "Animal", new { area = "" });

        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var animalEdit = this.animal.Details(id);

            if (animalEdit == null)
            {
                return NotFound();
            }

            return View(new EditAnimalFormModel
            {
                Name = animalEdit.Name,
                Age = animalEdit.Age,
                Description = animalEdit.Description,
                Aggressive = animalEdit.Aggressive,
                Neutered = animalEdit.Neutered,
                Breed = animalEdit.Breed,
                Gender = animalEdit.Gender,
                Color = animalEdit.Color,

            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, EditAnimalFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.animal.Edit(id,
                model.Name,
                model.Age,
                model.Aggressive,
                model.Description,
                model.Neutered,
                model.Vaccinated,
                model.Breed,
                model.Gender,
                model.Color
             
            );

            return RedirectToAction("All", "Animal", new {area = ""});
        }

    }
}
