using Hacky.rest.services;
using UnityEngine;
using System;
namespace Hacky.rest.models {

    [Serializable]
    public class Character   { 
        
        public string Id;
        public string Name;
        public string UserId;
        public string StatsId;
        public DateTime? CreatedAt;
        public DateTime? UpdatedAt;
       
    }





}
