using Hacky.rest.services;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Hacky.rest.models {

    [Serializable]
    public class Stat  { 
        
        public string statsId;
        
        public int level;
        
        public int experience;
        
        public DateTime createdAt;
        
        public DateTime updatedAt;
        
       
    }

    [Serializable]
    public class StatList
    { 
        public List<Stat> items;   
    }





}
