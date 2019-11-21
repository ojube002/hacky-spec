using Hacky.rest.services;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Hacky.rest.models {

    [Serializable]
    public class FullCharacter   { 
        
        public string characterId;
        
        public string name;
        
        public int? level;
        
        public int? experience;
        
       
    }

    [Serializable]
    public class FullCharacterList
    { 
        public List<FullCharacter> items;   
    }





}
