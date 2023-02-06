using Proyecto26;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMainEvents : UIBase
{
    // Start is called before the first frame update
    public Button btnNearby;
    public Button btnUpcomming;
    public GameObject fabEventItem;
    public Transform transItemList;
    public GameObject shareContent;
    public Button btnShareClose;
    public Text txtShareTitle;

    public GameObject fabTopEventItem;
    public Transform transTopItemList;

    public EventDetail eventDetail;

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
        eventDetail.Show2Hide(false);
        shareContent.SetActive(false);
        btnNearby.onClick.AddListener(onClickNearby);
        btnUpcomming.onClick.AddListener(onClickUpcomming);
        btnShareClose.onClick.AddListener(onClickShareClose);
        //UIManager.Instance.ShowPanel("eventPanel", UILayer.UI);
        Get<EventList>("/events", (eventsList) =>
        {
            DataManager.Instance.eventList = eventsList;
            UpdateEventList(DataManager.Instance.eventList);
        });
        Get<EventList>("/topEvents", (eventsList) =>
        {
            DataManager.Instance.topEventList = eventsList;
            UpdateTopEventList(DataManager.Instance.topEventList);
        });
    }


    private void onClickShareClose()
    {
        shareContent.SetActive(false);
    }

    private void onClickNearby()
    {
        Debug.Log("onClickNearby");
    }

    private void onClickUpcomming()
    {
        Debug.Log("onClickUpcomming");
    }

    public void onClickEventItem()
    {
        Debug.Log("onClickEventItem");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnReceive(UIEvent uiEvent, object obj)
    {

    }

    public void UpdateEventList(EventList envetList)
    {
        Debug.Log("UpdateEventList");
        if (envetList == null || envetList.eventName.Count == 0)
            return;
        int index = 0;
        Helper.DestroyObject(transItemList);
        foreach (var item in envetList.eventName)
        {
            var newObj = Helper.CreateObject(fabEventItem, transItemList);
            var eventItem = newObj.GetComponent<EventItem>();
            eventItem.SetEvent(item);
            Helper.AddEntry(eventItem.imgPicture.gameObject, onClickEventItem);
            eventItem.btnShare.onClick.AddListener(onClickShare);
            index++;
        }
    }

    public void UpdateTopEventList(EventList envetList)
    {
        Debug.Log("UpdateTopEventList");
        if (envetList == null || envetList.eventName.Count == 0)
            return;
        int index = 0;
        Helper.DestroyObject(transTopItemList);
        foreach (var item in envetList.eventName)
        {
            var newObj = Helper.CreateObject(fabTopEventItem, transTopItemList);
            var eventItem = newObj.GetComponent<TopEventItem>();
            eventItem.SetEvent(item);
            Helper.AddEntry(eventItem.imgPicture.gameObject, onClickTopEventItem);
            eventItem.btnShare.onClick.AddListener(onClickTopShare);
            index++;
        }
    }

    void onClickShare()
    {
        var obj = EventSystem.current.currentSelectedGameObject;
        var currentId = Int32.Parse(obj.name);
        shareContent.SetActive(!shareContent.activeSelf);
        var item = DataManager.Instance.eventList.eventName.Find(x => x.id == currentId);
        txtShareTitle.text = item.name;
    }

    void onClickTopShare()
    {
        var obj = EventSystem.current.currentSelectedGameObject;
        var currentId = Int32.Parse(obj.name);
        shareContent.SetActive(!shareContent.activeSelf);
        var item = DataManager.Instance.topEventList.eventName.Find(x => x.id == currentId);
        txtShareTitle.text = item.name;
    }

    void onClickEventItem(BaseEventData baseEvent)
    {
        Debug.Log("onClickEventItem");
        // get current click object
        var obj = Helper.GetCurrentObject();
        if (obj == null)
            return;
        var currentId = Int32.Parse(obj.name);
        var item = DataManager.Instance.eventList.eventName.Find(x => x.id == currentId);
        eventDetail.SetData(item);
    }

    void onClickTopEventItem(BaseEventData baseEvent)
    {
        Debug.Log("onClickTopEventItem");
        // get current click object
        var obj = Helper.GetCurrentObject();
        if (obj == null)
            return;
        var currentId = Int32.Parse(obj.name);
        var item = DataManager.Instance.topEventList.eventName.Find(x => x.id == currentId);
        eventDetail.SetData(item);
    }
}
