using Hacky.rest.services;
using UnityEngine;
using System;
namespace Hacky.rest.models {

    [Serializable]
    public class NotFound :  IJsonSerializable { 
        
        public int? Code;
        public string Message;
        public NotFound(string json)
        {
            var c = JsonUtility.FromJson<NotFound>(json);
            // copy fields
            Code = c.Code;
            Message = c.Message;
        }
        public string ToJson(){
            return JsonUtility.ToJson(this);
        }

        public static NotFound CreateFromJson(string json)
        {
            return JsonUtility.FromJson<NotFound>(json);
        }
    }






}
