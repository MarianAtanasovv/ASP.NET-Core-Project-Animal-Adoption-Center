using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAdoptionCenter.Services
{
    public interface INewsService 
    {
        public int Add(
            string title,
            string body,
            DateTime dateTime);
    }
}
