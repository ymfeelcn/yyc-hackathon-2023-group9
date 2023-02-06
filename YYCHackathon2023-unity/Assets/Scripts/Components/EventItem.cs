using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txtTitle;
    public Text txtDate;
    public Image imgPicture;
    public Image imgBackground;
    public Button btnShare;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEvent(EventModel eventModel)
    {
        name = eventModel.id.ToString();
        txtTitle.text = eventModel.name.Length > 40 ? eventModel.name.Substring(0, 40) + "..." : eventModel.name;
        txtDate.text = eventModel.eventDate;
        btnShare.name = eventModel.id.ToString();
        imgPicture.name = eventModel.id.ToString();
        //txtLocation.text = eventModel.eventLocation;
        APIManager.Instance.SetImage(imgPicture.gameObject, eventModel.eventImg);
        //APIManager.Instance.SetImage(imgBackground, eventModel.eventImg_url);
    }
}
