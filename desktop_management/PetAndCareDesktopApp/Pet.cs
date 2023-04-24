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


        public Pet(int iD, string petName, int age, string breed, string gender, bool castrated, string imgUserDefine, string description, string contactInfo,int petbreedid, DateTime createdAt, DateTime updatedAt)
        {
            ID = iD;
            PetName = petName;
            Age = age;
            Breed = breed;
            Gender = gender;
            Castrated = castrated;
            ImgUserDefine = imgUserDefine;
            Description = description;
            ContactInfo = contactInfo;
            PetBreedId = petbreedid;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int ID { get; set; }
        public string PetName { get; set; }
        public int Age { get; set; }    
        public string Breed { get; set; }
        public string Gender { get; set; }
        public bool Castrated { get; set; }
        public string ImgUserDefine { get; set; }
        public string Description { get; set; }

        public string ContactInfo { get; set; }

        public int PetBreedId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }



    }
}
