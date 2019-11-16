using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Hacky.services {

    public class NewsArticlesApi {

        /**
        * Creates news article
        * @summary Create news article
        * @param body Payload
        */
        public static void CreateNewsArticle( NewsArticle body  , Action<NewsArticle> onSuccess, Action<string> onError  ) {
           
           StartCoroutine(POST($"https://bittineuvos.com/api/newsArticles",onSuccess, onError, json));
        
        }


        /**
        * Deletes news article
        * @summary Delete news article
        * @param newsArticleId news article id id
        */
        public static void DeleteNewsArticle( int? newsArticleId  , Action<int?> onSuccess, Action<string> onError  ) {
           
           StartCoroutine(DELETE($"https://bittineuvos.com/api/newsArticles/{newsArticleId}",onSuccess, onError, json));
        
        }


        /**
        * Finds news article by id
        * @summary Find news article
        * @param newsArticleId news article id id
        */
        public static void FindNewsArticle( int? newsArticleId  , Action<int?> onSuccess, Action<string> onError  ) {
           
           StartCoroutine(GET($"https://bittineuvos.com/api/newsArticles/{newsArticleId}",onSuccess, onError, json));
        
        }


        /**
        * Lists news articles
        * @summary Lists news articles
        */
        public static void ListNewsArticles() {
           
           StartCoroutine(GET($"https://bittineuvos.com/api/newsArticles",onSuccess, onError, json));
        
        }


        /**
        * Updates news article
        * @summary Update news article
        * @param body Payload
        * @param newsArticleId news article id id
        */
        public static void UpdateNewsArticle( NewsArticle body    int? newsArticleId  , Action<int?> onSuccess, Action<string> onError  ) {
           
           StartCoroutine(PUT($"https://bittineuvos.com/api/newsArticles/{newsArticleId}",onSuccess, onError, json));
        
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