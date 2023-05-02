using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAndCareDesktopApp
{
    public class Dog : Pet
    {


        public Dog() { }

        public Dog(int iD, string petName, int age, string breed, int petbreedid, string gender, bool castrated,
            string imgUserDefine, string description) : 
            base(iD, petName, age, breed, petbreedid, gender, castrated, imgUserDefine, description)
        {
        }
    }
}
