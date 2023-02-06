using System;
using System.Collections;
using System.Linq;
using Models;
using Proyecto26;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIManager : MonoBehaviour
{
    private readonly string basePath = "http://127.0.0.1:4000/api";
    private RequestHelper currentRequest;
    public static APIManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void Get<T>(string apiName, Action<T> callback)
    {
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";
        RestClient.Get(basePath + apiName).Then(res =>
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res.Text);
            callback(result);
        }).Catch(err => Debug.Log("Error: " + err.Message));
    }

    public void SetImage(GameObject obj, string imageUrl)
    {
        StartCoroutine(DownloadImage(obj, imageUrl));
    }

    IEnumerator DownloadImage(GameObject obj, string imageUrl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
            yield return null;
        }
        Texture2D tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
        obj.GetComponent<Image>().overrideSprite = sprite;
    }

    public void UpdateHomeVideoList()
    {
        //Get<VideoPage>("/video", (videoPage) =>
        //{
        //    DataManager.Instance.videoPage = videoPage;
        //    UIManager.Instance.Dispatch(UIEvent.UPDATE_HOME_VIDEO_LIST, videoPage);
        //});
    }

    public void GetEventList()
    {
        Get<EventList>("/events", (eventsList) =>
        {
            DataManager.Instance.eventList = eventsList;
            UIManager.Instance.Dispatch(UIEvent.UPDATE_EVENT_LIST, eventsList);
        });
    }
}

