using AnimalAdoptionCenter.Data.Models;
using AnimalAdoptionCenter.Services.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services
{
    public interface IAnimalService
    {
        AnimalDetailsServiceModel Details(int id);
    }
}
