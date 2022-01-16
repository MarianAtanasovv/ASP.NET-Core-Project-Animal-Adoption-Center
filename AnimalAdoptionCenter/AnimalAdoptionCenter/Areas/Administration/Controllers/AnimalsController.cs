using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoptionCenter.Models.Animals;
using AnimalAdoptionCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

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

    }
}
