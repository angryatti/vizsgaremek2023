using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAndCareDesktopApp
{
    class Cat : Pet
    {
        public Cat(int iD, string petName, string breed, string gender, bool castrated, string imgUserDefine, string description, string contactInfo, DateTime createdAt, DateTime updatedAt) : base(iD, petName, breed, gender, castrated, imgUserDefine, description, contactInfo, createdAt, updatedAt)
        {
        }
    }
}
