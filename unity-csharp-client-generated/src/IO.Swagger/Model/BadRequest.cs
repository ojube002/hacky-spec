using Hacky.services;
using UnityEngine;
using System;
namespace Hacky.rest.models {

    [Serializable]
    public class BadRequest :  IJsonSerializable { 
        
        public int? Code;
        public string Message;
        public BadRequest(string json)
        {
            var c = JsonUtility.FromJson<BadRequest>(json);
            // copy fields
            Code = c.Code;
            Message = c.Message;
        }
        public string ToJson(){
            return JsonUtility.ToJson(this);
        }

        public static BadRequest CreateFromJson(string json)
        {
            return JsonUtility.FromJson<BadRequest>(json);
        }
    }






}
