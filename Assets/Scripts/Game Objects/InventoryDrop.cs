using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryDrop : DropSlot
{
    [SerializeField] InventoryScript inventoryScript;
    [SerializeField] GameObject AngelIntroController;
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Dropped into inventory");
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            occupant = eventData.pointerDrag.GetComponent<DragDrop>();

            inventoryScript.Add(occupant.word);
            Destroy(occupant.gameObject);
        }
        if (AngelIntroController != null)
        {
            AngelIntroController.GetComponent<AngelIntro>().done();
        }
    }

    public override void unoccupy(DragDrop dragDrop)
    {
        Debug.Log("Taking from inventory");
        inventoryScript.Take(dragDrop.word);
    }
}
