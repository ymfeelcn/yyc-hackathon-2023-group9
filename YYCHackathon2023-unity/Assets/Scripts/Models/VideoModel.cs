using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
      "id": 1,
      "name": "Calgary Downtown",
      "describtion": "Olympic Plaza ice skating",
      "url": "https://www.youtube.com/shorts/3lA2A-jCS1o",
      "eventDate": "Feb 15"
*/

[Serializable]
public class VideoModel
{
    public int id;
    public string name;
    public string describtion;
    public string url;
    public string eventDate;
}

[Serializable]
public class VideoList
{
    public List<VideoModel> videos;
}