using System;
using UnityEngine;
using Hacky.rest.models;
using Hacky.rest.utils;

namespace Hacky.rest.services {

   
    public sealed class UserApi : MonoBehaviour
    {
       private static UserApi _instance;

        public static UserApi Instance => _instance; 


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
        * Creates a new user
        * @summary Create user
        * @param body Payload
        */
        public void CreateUser( User body, Action<User> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("POST", $"https://bittineuvos.com/api/user",onSuccess, onError, token, JsonUtility.ToJson(body)));
        
        }

        /**
        * Deletes a user
        * @summary Deletes a user
        * @param userId user id
        */
        public void DeleteUser( string userId, Action<User> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("DELETE", $"https://bittineuvos.com/api/User/{userId}",onSuccess, onError, token));
        
        }

        /**
        * Finds user by id
        * @summary Find user
        * @param userId user id
        */
        public void FindUser( string userId, Action<User> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("GET", $"https://bittineuvos.com/api/User/{userId}",onSuccess, onError, token));
        
        }

        /**
        * Updates users information
        * @summary Updates user
        * @param body Payload
        */
        public void UpdateUser( User body, Action<UserList> onSuccess, Action<HttpError> onError, string token) {
            
           
           StartCoroutine(ApiUtils.Request("PUT", $"https://bittineuvos.com/api/user",onSuccess, onError, token, JsonUtility.ToJson(body)));
        
        }

       
    }

} 