using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropSlot : MonoBehaviour, IDropHandler
{
    public bool occupied;
    public DragDrop occupant;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            occupant = eventData.pointerDrag.GetComponent<DragDrop>();
            occupied = true;
            occupant.inSlot = true;
            occupant.slot = this;
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
    public void unoccupy()
    {
        occupied = false;
        occupant = null;
    }
}
