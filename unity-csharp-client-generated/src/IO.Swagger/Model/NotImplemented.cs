using Hacky.services;
using UnityEngine;
using System;
namespace Hacky.rest.models {

    [Serializable]
    public class NotImplemented :  IJsonSerializable { 
        
        public int? Code;
        public string Message;
        public NotImplemented(string json)
        {
            var c = JsonUtility.FromJson<NotImplemented>(json);
            // copy fields
            Code = c.Code;
            Message = c.Message;
        }
        public string ToJson(){
            return JsonUtility.ToJson(this);
        }

        public static NotImplemented CreateFromJson(string json)
        {
            return JsonUtility.FromJson<NotImplemented>(json);
        }
    }






}
