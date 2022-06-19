using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundTrigger : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] Sound eventType;
    bool isMouseDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isMouseDown = true;
        SoundManager.Instance.PlayPointerEvent(eventType, false);

        if (eventType == Sound.Wine)
            SoundManager.Instance.Drunk(true);
        else if (eventType == Sound.StopDrunk)
            SoundManager.Instance.Drunk(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (isMouseDown || Input.GetMouseButton(0))
        //    return;
        //SoundManager.Instance.PlayPointerEvent(eventType, false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMouseDown)
            SoundManager.Instance.PlayPointerEvent(eventType, true);


    }

}
