using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Hacky.services {

    public class CharactersApi {

        /**
        * Creates news article
        * @summary Create news article
        * @param body Payload
        */
        public IEnumerator CreateCharacter( Character Character ) {
            using (UnityWebRequest www = UnityWebRequest.POST("https://bittineuvos.com/api/characters"))
            {
                www.SetRequestHeader("Authorization",$"Bearer {token}");
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                    Debug.Log($"{www.responseCode} : {www.downloadHandler.text}");
                else
                    Debug.Log(www.downloadHandler.text);
            }
        }


        /**
        * Lists Characters
        * @summary Lists characters
        */
        public IEnumerator ListCharacters() {
            using (UnityWebRequest www = UnityWebRequest.GET("https://bittineuvos.com/api/characters"))
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