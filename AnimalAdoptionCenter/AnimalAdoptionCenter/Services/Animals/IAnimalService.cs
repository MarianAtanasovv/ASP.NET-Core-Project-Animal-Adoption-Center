using AnimalAdoptionCenter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services
{
    public interface IAnimalService
    {
        int Add(
            int id,
            string name,
            int age,
            string breed,
            Data.Models.Type type,
            Gender gender,
            bool aggressive);
    }
}
