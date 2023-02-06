using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIExplore : UIBase
{
    // Start is called before the first frame update
    public Button btnRes;
    public Button btnSearch;
    public Button btnLike;
    public Button btnShare;
    public Button btnMore;
    public VideoPlayer video;
    public Text txtTitle;

    public GameObject shareContent;
    public Text txtShareTitle;
    public Button btnShareClose;
    
    public int videoIndex = 0;
    public GameObject searchContent;

    private readonly string basePath = "http://127.0.0.1:4000/api";
    //private readonly string basePath = "http://3.98.129.103:4000/api";

    public void Get<T>(string apiName, Action<T> callback)
    {
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";
        RestClient.Get(basePath + apiName).Then(res =>
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res.Text);
            callback(result);
        }).Catch(err => Debug.Log("Error: " + err.Message));
    }

    void Start()
    {
        //video.url = videoList[0];
        shareContent.SetActive(false);
        searchContent.SetActive(false);
        btnRes.onClick.AddListener(onClickRes);
        btnSearch.onClick.AddListener(onClickSearch);
        btnShare.onClick.AddListener(onClickShare);
        btnLike.onClick.AddListener(onClickLike);
        btnMore.onClick.AddListener(onClickMore);
        btnShareClose.onClick.AddListener(onClickShareClose);

        Get<VideoList>("/videos", (videoList) =>
        {
            DataManager.Instance.videoList = videoList;
            if (videoList.videos.Count > 0)
                SetCurrentVideo(0);
            UpdateVideoList(videoList);
        });
    }


    private void onClickRes()
    {
        videoIndex++;
        if (videoIndex >= DataManager.Instance.videoList.videos.Count)
            videoIndex = 0;
        Debug.Log("onClickRes");
        SetCurrentVideo(videoIndex);
    }

    public void SetCurrentVideo(int index)
    {
        videoIndex = index;
        video.url = DataManager.Instance.videoList.videos[videoIndex].url;
        // change the title
        txtTitle.text = DataManager.Instance.videoList.videos[videoIndex].name;
    }

    private void onClickSearch()
    {
        Debug.Log("onClickSearch");
        searchContent.SetActive(!searchContent.activeSelf);
    }

    private void onClickShare()
    {
        Debug.Log("onClickShare");
        // set the title name;
        txtShareTitle.text = DataManager.Instance.videoList.videos[videoIndex].name;
        shareContent.SetActive(!shareContent.activeSelf);
    }

    private void onClickLike()
    {
        Debug.Log("onClickLike");
    }

    private void onClickMore()
    {
        Debug.Log("onClickMore");
    }

    private void onClickShareClose()
    {
        Debug.Log("onClickShareClose");
        shareContent.SetActive(false);
    }

    public void onClickEventItem()
    {
        Debug.Log("onClickEventItem");
    }

    public void UpdateVideoList(VideoList videoList)
    {
        Debug.Log("UpdateVideoList");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnReceive(UIEvent uiEvent, object obj)
    {
    }
}
