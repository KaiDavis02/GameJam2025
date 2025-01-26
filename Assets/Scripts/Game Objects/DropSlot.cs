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
    private List<Action<string>> actionList = new List<Action<string>>();
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
            Debug.Log("Slotted: " + occupant.word.text);
            if (speechBubble != null)
            {
                Debug.Log("Adding word: " + occupant.word.text);
                speechBubble.updateWords(occupant.word, slotNo);
            }
            WordChanged(occupant.word.text);
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
        dd.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
    }


    /**
     * Pass this a function taking a String. When word is changed, function will be
     * called, and passed the new word.
     */
    public void AddOnWordChangedEvent(Action<string> a)
    {
        Debug.Log("Event registered");
        actionList.Add(a);
    }

    /**
     * Trigger all functions listening for a word change.
     */
    private void WordChanged(string newWord)
    {
        Debug.Log("Word in slot has been changed");
        foreach (var a in actionList)
        {
            a.Invoke(newWord);
        }
    }
}
