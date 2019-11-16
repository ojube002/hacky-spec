using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Hacky.rest.services {

    interface IJsonSerializable
    {
        string ToJson();
    }


    public class CharactersApi {

        /**
        * Creates character
        * @summary Create character
        * @param body Payload
        */
        public static void CreateCharacter( Character body  , Action<Character> onSuccess, Action<string> onError, string token, string json = null  ) {
           
           StartCoroutine(Request("POST", $"https://bittineuvos.com/api/character",onSuccess, onError, token, json));
        
        }


        /**
        * Deletes a character
        * @summary Deletes a character
        * @param characterId character id
        */
        public static void DeleteCharacter( string characterId  , Action<string> onSuccess, Action<string> onError, string token, string json = null  ) {
           
           StartCoroutine(Request("DELETE", $"https://bittineuvos.com/api/character/{characterId}",onSuccess, onError, token, json));
        
        }


        /**
        * Finds character by id
        * @summary Find character
        * @param characterId character id
        */
        public static void FindCharacter( string characterId  , Action<string> onSuccess, Action<string> onError, string token, string json = null  ) {
           
           StartCoroutine(Request("GET", $"https://bittineuvos.com/api/character/{characterId}",onSuccess, onError, token, json));
        
        }


        /**
        * Lists Characters
        * @summary Lists characters
        * @param userId user id
        */
        public static void ListCharacters( string userId  , Action<string> onSuccess, Action<string> onError, string token, string json = null  ) {
           
           StartCoroutine(Request("GET", $"https://bittineuvos.com/api/character/list/{userId}",onSuccess, onError, token, json));
        
        }


        private static IEnumerator Request<T,K>(string reqmethod, string url, Action<T> onSuccess, Action<K> onError, string token, string json = null)
        {

            
            using (UnityWebRequest www = CreateRequest(reqmethod,url,data))
            {
                www.SetRequestHeader("Authorization",$"Bearer {token}");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log($"{www.responseCode} : {www.downloadHandler.text}");
                    onError($"{www.responseCode} : {www.downloadHandler.text}");
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    onSuccess(new T(www.downloadHandler.text));

                }
                 
            }
        }
        private static UnityWebRequest CreateRequest(string reqmethod, string url, string data = null)
        {
            if(reqmethod == "POST") return UnityWebRequest.Post(url,data);
            else if(reqmethod == "GET") return UnityWebRequest.Get(url);
            else if(reqmethod == "PUT") return UnityWebRequest.Put(url,data);
            else if(reqmethod == "DELETE") return UnityWebRequest.Delete(url);

        }
       
    }

} 