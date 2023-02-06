using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnEvents;
    public Button btnExplore;
    public Button btnCalendar;
    void Start()
    {
        btnEvents.onClick.AddListener(onClickEvents);
        btnExplore.onClick.AddListener(onClickExplore);
        btnCalendar.onClick.AddListener(onClickCalendar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onClickEvents()
    {
        Debug.Log("Events");
        SceneManager.LoadScene(0);
    }
    private void onClickExplore()
    {
        Debug.Log("Explore");
        SceneManager.LoadScene(2);
    }

    private void onClickCalendar()
    {
        Debug.Log("Calendar");
        SceneManager.LoadScene(1);
    }
}
