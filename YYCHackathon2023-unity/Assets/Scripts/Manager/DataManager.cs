using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; set; }
    public EventList eventList = new EventList();
    public EventList topEventList = new EventList();
    public VideoList videoList = new VideoList();
    public DateList dateList = new DateList();
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

    void Start()
    {

    }

    public string GetVideo()
    {
        //if (selectedVideoId == 0)
        //    return null;
        //string url = null;
        //foreach (var video in videoPage.list)
        //{
        //    if (video.id == selectedVideoId)
        //    {
        //        url = video.url;
        //        break;
        //    }
        //}
        //return url;
        return null;
    }
}