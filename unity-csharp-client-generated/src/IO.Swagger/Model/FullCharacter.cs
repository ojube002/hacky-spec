using Hacky.rest.services;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Hacky.rest.models {

    [Serializable]
    public class FullCharacter  { 
        
        public string id;
        
        public string name;
        
        public string userId;
        
        public string statsId;
        
        public DateTime createdAt;
        
        public DateTime updatedAt;
        
        public int level;
        
        public int experience;
        
       
    }

    [Serializable]
    public class FullCharacterList
    { 
        public List<FullCharacter> items;   
    }





}
