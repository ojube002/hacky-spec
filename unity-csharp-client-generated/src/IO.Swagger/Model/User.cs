using Hacky.rest.services;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Hacky.rest.models {

    [Serializable]
    public class User  { 
        
        public string firstname;
        
        public string lastname;
        
        public string username;
        
        public string email;
        
       
    }

    [Serializable]
    public class UserList
    { 
        public List<User> items;   
    }





}
