using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }
    public List<GameObject> panelFabsList;
    private List<UIPanelBase> panels = new List<UIPanelBase>();

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

    void Update()
    {

    }

    public void Dispatch(UIEvent uiEvent, object obj)
    {
        foreach (var panel in panels)
        {
            panel.OnReceive(uiEvent, obj);
        }
    }

    private GameObject getPanelFab(string name)
    {
        var panel = panelFabsList.Find(item => item.name == name);
        return panel;
    }

    private UIPanelBase getPanel(string name)
    {
        var panel = panels.Find(item => item.panelName == name);
        return panel;
    }

    public void ShowPanel(string name, UILayer layer)
    {
        CloseAllPanel();
        var panel = getPanel(name);
        if (panel != null)
        {
            panel.Show();
            return;
        }
        var uiframe = GameObject.Find("UIFrame");
        var parent = uiframe.transform.Find(Helper.GetLayerName(layer));
        // create new panel
        var obj = Helper.CreateObject(getPanelFab(name), parent);
        obj.name = name;
        var panelBase = obj.GetComponent<UIPanelBase>();
        panelBase.Show();
        panels.Add(panelBase);
    }

    public void ClosePanel(string name)
    {
        var panel = getPanel(name);
        if (panel != null)
        {
            panel.Close();
            return;
        }
    }

    public void CloseAllPanel()
    {
        foreach (var panel in panels)
            if (panel != null)
                panel.Close();
    }

    public void RemoveAllPanel()
    {
        panels.Clear();
    }
}