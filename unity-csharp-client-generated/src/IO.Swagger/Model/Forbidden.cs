using Hacky.services;
using UnityEngine;
using System;
namespace Hacky.rest.models {

    [Serializable]
    public class Forbidden :  IJsonSerializable { 
        
        public int? Code;
        public string Message;
        public Forbidden(string json)
        {
            var c = JsonUtility.FromJson<Forbidden>(json);
            // copy fields
            Code = c.Code;
            Message = c.Message;
        }
        public string ToJson(){
            return JsonUtility.ToJson(this);
        }

        public static Forbidden CreateFromJson(string json)
        {
            return JsonUtility.FromJson<Forbidden>(json);
        }
    }






}
