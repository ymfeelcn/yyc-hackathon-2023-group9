using UnityEngine;
using UnityEngine.UI;

public class EventDetail : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txtTitle;
    public Text txtDate;
    public Text txtDesc;
    public Button btnAdd;
    public Button btnClose;

    void Start()
    {
        btnAdd.onClick.AddListener(onClickAdd);
        btnClose.onClick.AddListener(onClickClose);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickClose()
    {
        gameObject.SetActive(false);
    }
    
    public void onClickAdd()
    {
        gameObject.SetActive(false);
        Debug.Log("onClickAdd");
    }

    public void Show2Hide(bool active)
    {
        gameObject.SetActive(active);
    }

    public void SetData(EventModel eventModel)
    {
        txtTitle.text = eventModel.name;
        txtDate.text = eventModel.eventDate;
        gameObject.SetActive(true);
    }
}
