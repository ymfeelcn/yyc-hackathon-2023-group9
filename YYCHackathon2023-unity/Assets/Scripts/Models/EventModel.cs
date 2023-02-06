using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *  "eventName": [
  {
   "name": "Potion Putt - A Wizardry Mini-Golf Course: Calgary",
   "url": "https://explorehidden.com/event/details/potion-putt-a-wizardry-mini-golf-course-calgary-1552042",
   "eventDate": "Until 28-Feb-2023",
   "eventDate_url": "https://explorehidden.com/event/details/potion-putt-a-wizardry-mini-golf-course-calgary-1552042",
   "eventImg": "https://hiddencdn.s3-ap-southeast-2.amazonaws.com/events/thumb_15426.png",
   "eventImg_url": "https://explorehidden.com/event/details/potion-putt-a-wizardry-mini-golf-course-calgary-1552042",
   "eventPrice": "C$0 - C$19.00",
   "eventPrice_url": "https://explorehidden.com/event/details/potion-putt-a-wizardry-mini-golf-course-calgary-1552042"
  },
*/

[Serializable]
public class EventModel
{
    public int id;
    public string name;
    public string url;
    public string eventDate;
    public string eventDate_url;
    public string eventImg;
    public string eventImg_url;
    public string eventPrice;
    public string eventPrice_url;
}

[Serializable]
public class EventList
{
    public List<EventModel> eventName;
}