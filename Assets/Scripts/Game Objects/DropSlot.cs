using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropSlot : MonoBehaviour, IDropHandler
{
    public bool occupied;
    public DragDrop occupant;
    public SpeechBubble speechBubble;
    public int slotNo;
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            occupant = eventData.pointerDrag.GetComponent<DragDrop>();
            occupied = true;
            occupant.inSlot = true;
            occupant.slot = this;
            if (speechBubble != null)
            {
                speechBubble.updateWords(occupant.word, slotNo);
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        occupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void unoccupy(DragDrop dragDrop)
    {
        occupied = false;
        occupant = null;
        speechBubble?.updateWords(new Word(), slotNo);
    }
    public void occupy(DragDrop dd)
    {
        occupied = true;
        occupant = dd;
        dd.slot = this;
        dd.inSlot = true;
    }
}
