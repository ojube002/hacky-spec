using System;
using UnityEngine;
using Hacky.rest.models;
using Hacky.rest.utils;

namespace Hacky.rest.services {

   
    public sealed class FullCharacterApi : MonoBehaviour
    {
       private static FullCharacterApi _instance;

        public static FullCharacterApi Instance => _instance; 


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
        * Lists Characters
        * @summary Lists characters
        */
        public void ListCharacters( Action<FullCharacterList> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("GET", $"https://bittineuvos.com/api/characterlist",onSuccess, onError, token));
        
        }

       
    }

} 