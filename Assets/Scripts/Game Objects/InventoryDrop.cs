using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryDrop : DropSlot
{
    [SerializeField] InventoryScript inventoryScript;
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Dropped into inventory");
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            occupant = eventData.pointerDrag.GetComponent<DragDrop>();

            inventoryScript.Add(occupant.word);
            Destroy(occupant.gameObject);
        }
    }

    public override void unoccupy(DragDrop dragDrop)
    {
        Debug.Log("Taking from inventory");
        inventoryScript.Take(dragDrop.word);
    }
}
