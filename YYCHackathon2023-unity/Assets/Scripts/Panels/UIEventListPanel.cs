using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventListPanel : UIPanelBase
{
    public GameObject fabEventItem;
    public Transform transItemList;
    public List<EventItem> eventItems;
    public override void OnReceive(UIEvent uiEvent, object obj)
    {
        switch (uiEvent)
        {
            case UIEvent.UPDATE_EVENT_LIST:
                UpdateEventList(obj as EventList);
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void UpdateEventList(EventList envetList)
    {
        Debug.Log("UpdateEventList");
        if (envetList == null || envetList.eventName.Count == 0)
            return;
        int index = 0;
        Helper.DestroyObject(transItemList);
        foreach (var item in envetList.eventName)
        {
            var newObj = Helper.CreateObject(fabEventItem, transItemList);
            //newObj.name = item.id.ToString();
            //APIManager.Instance.SetImage(newObj, item.eventImg_url);
            // add click event
            Helper.AddEntry(newObj, onClickEventItem);
            index++;
        }
    }

    void onClickEventItem(BaseEventData baseEvent)
    {
        // get current click object
        var obj = Helper.GetCurrentObject();
        if (obj == null)
            return;
        Debug.Log("onClickEventItem=" + obj.name);
    }
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
