using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class UIEventTrigger : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public Action<GameObject, PointerEventData> onClick;
    public Action<GameObject, PointerEventData> onPointerEnter;
    public static UIEventTrigger Get(GameObject obj)
    {
        UIEventTrigger trigger = obj.GetComponent<UIEventTrigger>();
        if (trigger == null)
        {
            trigger = obj.AddComponent<UIEventTrigger>();
        }
        return trigger;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("onPointerClick");
        if (onClick != null)
        {
            onClick(gameObject, eventData);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("onPointerEnter");
        if (onPointerEnter != null)
        {
            onPointerEnter(gameObject, eventData);
        }
    }
}
