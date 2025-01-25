using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerDownHandler
{

    [SerializeField] Canvas canvas;
    RectTransform rect;
    CanvasGroup canvasGroup;
    public bool inSlot;
    public DropSlot slot;
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        if (inSlot)
        {
            inSlot = false;
            slot.unoccupy();
        }
        

        Debug.Log("Begin Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        Debug.Log("End Drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
