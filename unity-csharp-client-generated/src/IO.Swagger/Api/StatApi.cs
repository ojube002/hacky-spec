using System;
using UnityEngine;
using Hacky.rest.models;
using Hacky.rest.utils;

namespace Hacky.rest.services {

   
    public sealed class StatApi : MonoBehaviour
    {
       private static StatApi _instance;

        public static StatApi Instance => _instance; 


        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }
        /**
        * Creates a new stat
        * @summary Create stat
        * @param body Payload
        */
        public void CreateStat( Stat body, Action<Stat> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("POST", $"https://bittineuvos.com/api/stat",onSuccess, onError, token, JsonUtility.ToJson(body)));
        
        }

        /**
        * Deletes a stat
        * @summary Deletes a stat
        * @param characterId stat id
        */
        public void DeleteStat( int? characterId, Action<Stat> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("DELETE", $"https://bittineuvos.com/api/stat/{characterId}",onSuccess, onError, token, JsonUtility.ToJson(characterId)));
        
        }

        /**
        * Finds stat by characterId
        * @summary Find stat
        * @param characterId character id
        */
        public void FindStat( string characterId, Action<Stat> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("GET", $"https://bittineuvos.com/api/stat/{characterId}",onSuccess, onError, token));
        
        }

        /**
        * Updates stat information
        * @summary Updates stat
        * @param body Payload
        */
        public void UpdateStat( Stat body, Action<StatList> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("PUT", $"https://bittineuvos.com/api/stat",onSuccess, onError, token, JsonUtility.ToJson(body)));
        
        }

       
    }

} 