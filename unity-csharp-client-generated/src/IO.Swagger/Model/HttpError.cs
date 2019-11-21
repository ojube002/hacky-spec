using Hacky.rest.services;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Hacky.rest.models {

    [Serializable]
    public class HttpError  { 
        
        public int code;
        
        public string message;
        
       
    }

    [Serializable]
    public class HttpErrorList
    { 
        public List<HttpError> items;   
    }





}
