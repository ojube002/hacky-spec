using Hacky.services;
using UnityEngine;
using System;
namespace Hacky.rest.models {

    [Serializable]
    public class Character :  IJsonSerializable { 
        
        public string Id;
        public string Name;
        public string UserId;
        public string StatsId;
        public DateTime? CreatedAt;
        public DateTime? UpdatedAt;
        public Character(string json)
        {
            var c = JsonUtility.FromJson<Character>(json);
            // copy fields
            Id = c.Id;
            Name = c.Name;
            UserId = c.UserId;
            StatsId = c.StatsId;
            CreatedAt = c.CreatedAt;
            UpdatedAt = c.UpdatedAt;
        }
        public string ToJson(){
            return JsonUtility.ToJson(this);
        }

        public static Character CreateFromJson(string json)
        {
            return JsonUtility.FromJson<Character>(json);
        }
    }






}
