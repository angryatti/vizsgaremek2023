using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAndCareDesktopApp
{
    public class Pet
    {

        public Pet()
        {


        }


        public Pet(int iD, string petName, int age, string breed, string petbreed, string gender, bool castrated, string imgUserDefine, string description)
        {
            ID = iD;
            PetName = petName;
            Age = age;
            Breed = breed;
            PetBreed = petbreed;
            Gender = gender;
            Castrated = castrated;
            ImgUserDefine = imgUserDefine;
            Description = description;
       
         
        }

        public int ID { get; set; }
        public string PetName { get; set; }
        public int Age { get; set; }    
        public string Breed { get; set; }
        public string Gender { get; set; }
        public bool Castrated { get; set; }
        public string ImgUserDefine { get; set; }
        public string Description { get; set; }

        public string PetBreed { get; set; }


    }
}
