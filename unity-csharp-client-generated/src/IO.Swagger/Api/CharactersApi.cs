using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Hacky.services {

    public class CharactersApi {

        /**
        * Creates new character
        * @summary Create new character
        * @param character character object
        */
        public static void CreateCharacter( Character character  , Action<Character> onSuccess, Action<string> onError  ) {
           
           StartCoroutine(POST($"https://bittineuvos.com/api/characters",onSuccess, onError, json));
        
        }


        /**
        * Lists Characters
        * @summary Lists characters
        */
        public static void ListCharacters() {
           
           StartCoroutine(GET($"https://bittineuvos.com/api/characters",onSuccess, onError, json));
        
        }


        private static IEnumerator GET(string url, Action<string> onSuccess, Action<string> onError, string json = null){

            using (UnityWebRequest www = UnityWebRequest.Get(url))
            {
                www.SetRequestHeader("Authorization",$"Bearer {token}");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                    Debug.Log($"{www.responseCode} : {www.downloadHandler.text}");
                else
                    Debug.Log(www.downloadHandler.text);

                 
            }
        }

        private static IEnumerator POST(string url, Action<string> onSuccess, Action<string> onError, string json = null){

            Debug.AssertFormat(json == null, "json is null, check json parameter");
            using (UnityWebRequest www = UnityWebRequest.Post(url,json))
            {
                www.SetRequestHeader("Authorization",$"Bearer {token}");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                    Debug.Log($"{www.responseCode} : {www.downloadHandler.text}");
                else
                    Debug.Log(www.downloadHandler.text);

                 
            }
        }

        private static IEnumerator PUT(string url, Action<string> onSuccess, Action<string> onError, string json = null){
            
            Debug.AssertFormat(json == null, "json is null, check json parameter");
            using (UnityWebRequest www = UnityWebRequest.Put(url),json)
            {
                www.SetRequestHeader("Authorization",$"Bearer {token}");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                    Debug.Log($"{www.responseCode} : {www.downloadHandler.text}");
                else
                    Debug.Log(www.downloadHandler.text);

                 
            }
        }

        private static IEnumerator DELETE(string url, Action<string> onSuccess, Action<string> onError, string json = null){

            using (UnityWebRequest www = UnityWebRequest.Delete(url))
            {
                www.SetRequestHeader("Authorization",$"Bearer {token}");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                    Debug.Log($"{www.responseCode} : {www.downloadHandler.text}");
                else
                    Debug.Log(www.downloadHandler.text);

                 
            }
        }
    }

} 