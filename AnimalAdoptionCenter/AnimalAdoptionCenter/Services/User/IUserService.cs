using AnimalAdoptionCenter.Data.Models;
using System.Collections.Generic;

namespace AnimalAdoptionCenter.Services.User
{
    public interface IUserService
    {
        string IdUser(string userId);
        string Username(string userId);
    }
}
