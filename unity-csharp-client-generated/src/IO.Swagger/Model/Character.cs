using Hacky.rest.services;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Hacky.rest.models {

    [Serializable]
    public class Character  { 
        
        public string id;
        
        public string name;
        
        public string classType;
        
        public string userId;
        
        public string statsId;
        
        public DateTime createdAt;
        
        public DateTime updatedAt;
        
       
    }

    [Serializable]
    public class CharacterList
    { 
        public List<Character> items;   
    }





}
