using System;


namespace PetAndCareDesktopApp
{
    
        [Serializable]
        class PetException : Exception
        {
            public PetException() { }
            
            public PetException(string values)
                : base(String.Format("Nem megfelelő érték(ek): {0}", values))
            {

            }
        }
    
}
