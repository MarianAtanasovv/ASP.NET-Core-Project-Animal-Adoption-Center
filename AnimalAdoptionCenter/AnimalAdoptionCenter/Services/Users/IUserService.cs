using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services.Users
{
    public interface IUserService
    {
        string IdUser(string userId);
        string Username(string userId);

    }
}
