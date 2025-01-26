using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerDownHandler
{

    [SerializeField] Canvas canvas;
    RectTransform rect;
    public CanvasGroup canvasGroup;
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
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();

        TextMeshProUGUI childTMP = GetComponentInChildren<TextMeshProUGUI>();
        Word tmpWord = new Word();
        tmpWord.text = childTMP.text;
        SetWord(tmpWord);
    }

    public void SetWord(Word w)
    {
        word = w;
        TextMeshProUGUI childTMP = GetComponentInChildren<TextMeshProUGUI>();
        childTMP.text = w.text;
        Debug.Log("Draggable created with word: " + w.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
