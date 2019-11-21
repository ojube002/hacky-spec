using System;
using UnityEngine;
using Hacky.rest.models;
using Hacky.rest.utils;

namespace Hacky.rest.services {

   
    public sealed class CharacterApi : MonoBehaviour
    {
       private static CharacterApi _instance;

        public static CharacterApi Instance => _instance; 


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
        * Creates character
        * @summary Create character
        * @param body Payload
        */
        public void CreateCharacter( Character body, Action<Character> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("POST", $"https://bittineuvos.com/api/character",onSuccess, onError, token, JsonUtility.ToJson(body)));
        
        }

        /**
        * Deletes a character
        * @summary Deletes a character
        * @param characterId character id
        */
        public void DeleteCharacter( string characterId, Action<Character> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("DELETE", $"https://bittineuvos.com/api/character/{characterId}",onSuccess, onError, token));
        
        }

        /**
        * Finds character by id
        * @summary Find character
        * @param characterId character id
        */
        public void FindCharacter( string characterId, Action<Character> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("GET", $"https://bittineuvos.com/api/character/{characterId}",onSuccess, onError, token));
        
        }

       
    }

} 