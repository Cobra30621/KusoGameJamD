using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractableObject : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public ActiveWay ActiveWay;
    private bool isMouseInside;
    private Vector2 mousePos
    { get { return Input.mousePosition; } }
    private Vector2 clickPos;
    private Vector2 originPos;
    private RectTransform rectTransform;
    private bool isDraging = false;
    private bool canActive = false;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originPos = rectTransform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        if (isMouseInside || isDraging)
        {
            if (Input.GetMouseButton(0))
            {
                switch (ActiveWay)
                {
                    case ActiveWay.DragOn:
                        if (Input.GetMouseButtonDown(0))
                        {
                            clickPos = mousePos;
                            isDraging = true;
                        }
                        rectTransform.position = originPos + mousePos - clickPos;
                        break;

                    case ActiveWay.Click:
                        if(Input.GetMouseButtonDown(0))
                            OnActiveEvent();
                        break;
                }
            }
            // reset when mouse up
            if (Input.GetMouseButtonUp(0))
            {
                rectTransform.position = originPos;
                isDraging = false;
                if (canActive)
                    OnActiveEvent();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ActiveRange")
            canActive = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ActiveRange")
            canActive = false;
    }
    public abstract void OnActiveEvent();

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseInside = false;
    }
}

public enum ActiveWay
{
    DragOn,
    Click
}
