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
        public IEnumerator CreateNewsArticle( NewsArticle NewsArticle ) {
            using (UnityWebRequest www = UnityWebRequest.POST("https://bittineuvos.com/api/newsArticles"))
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
        * Deletes news article
        * @summary Delete news article
        * @param newsArticleId news article id id
        */
        public IEnumerator DeleteNewsArticle( int? int? ) {
            using (UnityWebRequest www = UnityWebRequest.DELETE("https://bittineuvos.com/api/newsArticles/{newsArticleId}"))
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
        * Finds news article by id
        * @summary Find news article
        * @param newsArticleId news article id id
        */
        public IEnumerator FindNewsArticle( int? int? ) {
            using (UnityWebRequest www = UnityWebRequest.GET("https://bittineuvos.com/api/newsArticles/{newsArticleId}"))
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
        * Lists news articles
        * @summary Lists news articles
        */
        public IEnumerator ListNewsArticles() {
            using (UnityWebRequest www = UnityWebRequest.GET("https://bittineuvos.com/api/newsArticles"))
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
        * Updates news article
        * @summary Update news article
        * @param body Payload
        * @param newsArticleId news article id id
        */
        public IEnumerator UpdateNewsArticle( NewsArticle NewsArticle  int? int? ) {
            using (UnityWebRequest www = UnityWebRequest.PUT("https://bittineuvos.com/api/newsArticles/{newsArticleId}"))
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