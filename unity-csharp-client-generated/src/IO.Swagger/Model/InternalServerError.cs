using Hacky.services;
using UnityEngine;
using System;
namespace Hacky.rest.models {

    [Serializable]
    public class InternalServerError :  IJsonSerializable { 
        
        public int? Code;
        public string Message;
        public InternalServerError(string json)
        {
            var c = JsonUtility.FromJson<InternalServerError>(json);
            // copy fields
            Code = c.Code;
            Message = c.Message;
        }
        public string ToJson(){
            return JsonUtility.ToJson(this);
        }

        public static InternalServerError CreateFromJson(string json)
        {
            return JsonUtility.FromJson<InternalServerError>(json);
        }
    }






}
