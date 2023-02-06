using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopEventItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txtTitle;
    public Text txtDate;
    public Image imgPicture;
    public EventModel eventModel;
    public Button btnShare;
    

    void Start()
    {
        //Helper.AddEntry(imgPicture.gameObject, onClickEventItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEvent(EventModel eventModel)
    {
        name = eventModel.id.ToString();
        this.eventModel = eventModel;
        txtTitle.text = eventModel.name;
        txtDate.text = eventModel.eventDate;
        btnShare.name = eventModel.id.ToString();
        imgPicture.name = eventModel.id.ToString();
        APIManager.Instance.SetImage(imgPicture.gameObject, eventModel.eventImg);
    }

    //public void onClickEventItem(BaseEventData eventData)
    //{
    //    Debug.Log("onClickTopEventItem");
    //}
}
