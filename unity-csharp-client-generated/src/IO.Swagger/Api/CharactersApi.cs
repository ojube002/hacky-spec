using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Hacky.rest.models;

namespace Hacky.rest.services {

    interface IJsonSerializable
    {
        string ToJson();
    }


    public sealed class CharactersApi : MonoBehaviour
    {
        private CharactersApi() {}  
        private static readonly Lazy<CharactersApi> lazy = new Lazy<CharactersApi>(() => new CharactersApi());  
        public static CharactersApi Instance  
        {  
            get  
            {  
                return lazy.Value;  
            }  
        }  

        /**
        * Creates character
        * @summary Create character
        * @param body Payload
        */
        public void CreateCharacter( Character body  , Action<Character> onSuccess, Action<string> onError, string token, string json = null  ) {
           
           StartCoroutine(Request("POST", $"https://bittineuvos.com/api/character",onSuccess, onError, token, json));
        
        }

        /**
        * Deletes a character
        * @summary Deletes a character
        * @param characterId character id
        */
        public void DeleteCharacter( string characterId  , Action<string> onSuccess, Action<string> onError, string token, string json = null  ) {
           
           StartCoroutine(Request("DELETE", $"https://bittineuvos.com/api/character/{characterId}",onSuccess, onError, token, json));
        
        }

        /**
        * Finds character by id
        * @summary Find character
        * @param characterId character id
        */
        public void FindCharacter( string characterId  , Action<string> onSuccess, Action<string> onError, string token, string json = null  ) {
           
           StartCoroutine(Request("GET", $"https://bittineuvos.com/api/character/{characterId}",onSuccess, onError, token, json));
        
        }

        /**
        * Lists Characters
        * @summary Lists characters
        * @param userId user id
        */
        public void ListCharacters( string userId  , Action<string> onSuccess, Action<string> onError, string token, string json = null  ) {
           
           StartCoroutine(Request("GET", $"https://bittineuvos.com/api/character/list/{userId}",onSuccess, onError, token, json));
        
        }


        private IEnumerator Request<TModel,TError>(string reqmethod, string url, Action<TModel> onSuccess, Action<TError> onError, string token, string json = null)
        {

            
            using (UnityWebRequest www = CreateRequest(reqmethod,url,json))
            {
                www.SetRequestHeader("Authorization",$"Bearer {token}");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log($"{www.responseCode} : {www.downloadHandler.text}");
                    var error = (TError)Activator.CreateInstance(typeof(TError), www.downloadHandler.text);
                    onError(error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    var model = (TModel)Activator.CreateInstance(typeof(TModel), www.downloadHandler.text);
                    onSuccess(model);

                }
                 
            }
        }
        private UnityWebRequest CreateRequest(string reqmethod, string url, string data = null)
        {
            if(reqmethod == "POST") return UnityWebRequest.Post(url,data);
            else if(reqmethod == "GET") return UnityWebRequest.Get(url);
            else if(reqmethod == "PUT") return UnityWebRequest.Put(url,data);
            else if(reqmethod == "DELETE") return UnityWebRequest.Delete(url);
            return null;
        }
       
    }

} 