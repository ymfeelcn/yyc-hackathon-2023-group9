using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnRes;
    public Button btnSearch;
    public List<GameObject> eventItems;

    void Start()
    {
        btnRes.onClick.AddListener(onClickRes);
        btnSearch.onClick.AddListener(onClickSearch);
    }


    private void onClickRes()
    {
        
    }

    private void onClickSearch()
    {
        Debug.Log("onClickSearch");
    }

    public void onClickEventItem()
    {
        Debug.Log("onClickEventItem");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
