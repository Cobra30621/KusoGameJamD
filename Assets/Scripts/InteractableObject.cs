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
    private bool isDraging = false;
    private bool canActive = false;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        originPos = rectTransform.anchoredPosition;
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
                        OnActiveEvent();
                    }
                    break;
            }
            // reset when mouse up
            if (Input.GetMouseButtonUp(0))
            {
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
        if (activeMaterial != null)
        {
            image.material = activeMaterial;
        }
        isMouseInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (defaultMaterial != null)
        {
            image.material = defaultMaterial;
        }
        isMouseInside = false;
    }
}

public enum ActiveWay
{
    DragOn,
    Click
}
