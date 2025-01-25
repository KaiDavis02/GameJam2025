using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerDownHandler
{

    [SerializeField] Canvas canvas;
    RectTransform rect;
    CanvasGroup canvasGroup;
    public bool inSlot;
    public DropSlot slot;
    public Word word = new Word();
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        if (inSlot)
        {
            inSlot = false;
            slot.unoccupy(this);
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();
        //TODO --- THIS IS FOR DEBUG STUFF
        word.text = "Key";
    }

    public void SetWord(string txt)
    {
        word.text = txt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
