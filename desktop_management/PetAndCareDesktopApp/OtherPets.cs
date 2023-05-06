using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAndCareDesktopApp
{
    public class OtherPets : Pet
    {
        public OtherPets(int iD, string petName,int age, string breed, string petbreed, string gender, bool castrated, string imgUserDefine, string description) : base(iD,  petName, age, breed, petbreed, gender, castrated, imgUserDefine, description) 
        {
        }
    }
}
