﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAndCareDesktopApp
{
    public class Dog : Pet
    {


        public Dog() { }

        public Dog(int iD, string petName, int age, string breed, string petbreed, string gender, bool castrated,
            string imgUserDefine, string description) : 
            base(iD, petName, age, breed, petbreed, gender, castrated, imgUserDefine, description)
        {
        }
    }
}
