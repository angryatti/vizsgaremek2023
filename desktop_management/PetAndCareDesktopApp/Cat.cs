﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAndCareDesktopApp
{
    class Cat : Pet
    {
        public Cat(int iD, string petName, int age,string breed, string gender, bool castrated, string imgUserDefine, string description, 
            string contactInfo, int petbreedid, DateTime createdAt, DateTime updatedAt) :
            base(iD, petName, age, breed, gender, castrated, imgUserDefine, description, contactInfo, petbreedid, createdAt, updatedAt)
        {
        }
    }
}
