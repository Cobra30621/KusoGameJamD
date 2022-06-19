using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class InteractableObject : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public ActiveWay ActiveWay;
    private bool isMouseInside;
    [SerializeField]
    private Material defaultMaterial = null;
    [SerializeField]
    private Material activeMaterial = null;
    private Image image;
    private Vector3 mousePos
    { get { return Input.mousePosition; } }
    private Vector3 clickPos;
    private Vector3 originPos;
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDraging = false;
    private bool canActive = false;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        originPos = rectTransform.anchoredPosition;
        canvas = GameObject.FindGameObjectWithTag("canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (isMouseInside || isDraging)
        {
            switch (ActiveWay)
            {
                case ActiveWay.DragOn:
                    if (Input.GetMouseButtonDown(0))
                    {
                        clickPos = mousePos;
                        isDraging = true;
                    }
                    if (isDraging)
                    {
                        rectTransform.anchoredPosition = originPos + mousePos - clickPos;
                        //rectTransform.anchoredPosition = new Vector3(rectTransform.position.x, rectTransform.position.y,0);
                    }
                    break;

                case ActiveWay.Click:
                    if (Input.GetMouseButtonDown(0))
                    {
                        if(activeMaterial != null)
                        {
                            image.material = activeMaterial;
                        }
                        OnActiveEvent();
                    }
                    break;
            }
            // reset when mouse up
            if (Input.GetMouseButtonUp(0))
            {
                if (defaultMaterial != null)
                {
                    image.material = defaultMaterial;
                }
                rectTransform.anchoredPosition = originPos;
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

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerEvent = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerEvent.position,
            canvas.worldCamera,
            out position);

        position = canvas.transform.TransformPoint(position);
        transform.position = canvas.transform.TransformPoint(position);
    }
}

public enum ActiveWay
{
    DragOn,
    Click
}
