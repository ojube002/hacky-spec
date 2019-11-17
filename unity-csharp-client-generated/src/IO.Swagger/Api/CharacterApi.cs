using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using Hacky.rest.models;

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
            
           
           StartCoroutine(Request("POST", $"https://bittineuvos.com/api/character",onSuccess, onError, token, JsonUtility.ToJson(body)));
        
        }

        /**
        * Deletes a character
        * @summary Deletes a character
        * @param characterId character id
        */
        public void DeleteCharacter( string characterId, Action<Character> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(Request("DELETE", $"https://bittineuvos.com/api/character/{characterId}",onSuccess, onError, token));
        
        }

        /**
        * Finds character by id
        * @summary Find character
        * @param characterId character id
        */
        public void FindCharacter( string characterId, Action<Character> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(Request("GET", $"https://bittineuvos.com/api/character/{characterId}",onSuccess, onError, token));
        
        }

        /**
        * Lists Characters
        * @summary Lists characters
        * @param userId user id
        */
        public void ListCharacters( string userId, Action<CharacterList> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(Request("GET", $"https://bittineuvos.com/api/character/list/{userId}",onSuccess, onError, token));
        
        }


        private IEnumerator Request<TModel,TError>(string reqmethod, string url, Action<TModel> onSuccess, Action<TError> onError, string token, string data = null)
        {

            
            using (UnityWebRequest www = CreateRequest(reqmethod,url,data))
            {
                if(www == null) throw new NullReferenceException($"CreateRequest: no reqmethod {reqmethod} found");
                if(data != null) www.SetRequestHeader("Content-Type", "application/json");
                www.SetRequestHeader("Authorization",$"Bearer {token}");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log($"{www.responseCode} : {www.downloadHandler.text}");
                    var error = JsonUtility.FromJson<TError>(www.downloadHandler.text);
                    onError(error);
                    //onError($"{www.responseCode} : {www.downloadHandler.text}");
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    var model = JsonUtility.FromJson<TModel>(JsonHelper.fixJson(www.downloadHandler.text));
                    onSuccess(model);

                }
                 
            }
        }
       private UnityWebRequest CreateRequest(string reqmethod, string url, string data = null)
        {
            if (reqmethod == "POST")
            {
                var request = new UnityWebRequest(url, "POST");
                byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(data);
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                return request;
                //return UnityWebRequest.Post(url, data);
            }
            else if (reqmethod == "GET") return UnityWebRequest.Get(url);
            else if (reqmethod == "PUT") return UnityWebRequest.Put(url, data);
            else if (reqmethod == "DELETE") return UnityWebRequest.Delete(url);
            return null;
        }

       
    }

} 