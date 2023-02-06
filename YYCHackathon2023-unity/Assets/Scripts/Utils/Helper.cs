using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;

public class Helper : MonoBehaviour
{

    public static void AddEntry(GameObject obj, UnityAction<BaseEventData> callback)
    {
        if (obj == null)
            return;
        // get eventTrigger
        var eventTrigger = obj.GetComponent<EventTrigger>();
        if (eventTrigger == null)
        {
            // add an eventTrigger components if it is null
            eventTrigger = obj.AddComponent<EventTrigger>();
        }
        if (eventTrigger.triggers == null)
        {
            // create a new eventTrigger list if it is null
            eventTrigger.triggers = new List<EventTrigger.Entry>();
        }
        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(callback);
        eventTrigger.triggers.Add(entry);
    }

    public static bool IsClickOn2DEntity()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hit = Physics2D.Raycast(new Vector2(pos.x, pos.y), new Vector2());
        if (hit.collider != null)
            return true;
        return false;
    }

    public static GameObject GetCurrentObject()
    {
        return UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
    }

    public static void DestroyObject(Transform trans)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            GameObject.Destroy(trans.GetChild(i).gameObject);
        }
    }

    public static GameObject CreateObject(GameObject fab, Transform parent)
    {
        var newObj = Instantiate(fab, Vector3.zero, Quaternion.identity) as GameObject;
        newObj.transform.SetParent(parent);
        newObj.transform.localScale = new Vector3(1, 1, 1);
        newObj.transform.localPosition = new Vector3(0, 0, 0);
        return newObj;
    }

    IEnumerator DownloadImage(GameObject obj, string imageUrl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(www.error);
            yield return null;
        }
        Texture2D tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
        obj.GetComponent<Image>().overrideSprite = sprite;
    }

    public static string GetLayerName(UILayer layer)
    {
        var layerName = "UI";
        switch (layer)
        {
            case UILayer.UI:
                layerName = "UI";
                break;
            case UILayer.DIALOG:
                layerName = "Dialog";
                break;
        }
        return layerName;
    }
}

