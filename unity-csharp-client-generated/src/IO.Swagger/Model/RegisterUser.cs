using Hacky.rest.services;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Hacky.rest.models {

    [Serializable]
    public class RegisterUser   { 
        
        public string username;
        
        public string password;
        
        public string email;
        
       
    }

    [Serializable]
    public class RegisterUserList
    { 
        public List<RegisterUser> items;   
    }





}
