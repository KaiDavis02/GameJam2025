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
    [HideInInspector] public bool inSlot;
    [HideInInspector] public DropSlot slot;
    [HideInInspector] public Word word = new Word();
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        transform.parent = canvas.transform;
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
        TextMeshProUGUI childTMP = GetComponentInChildren<TextMeshProUGUI>();
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();
        SetWord(childTMP.text);
    }

    public void SetWord(string txt)
    {
        word.text = txt;
        Debug.Log("Draggable created with word: " + txt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
