using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InventoryDrop : DropSlot
{
    [SerializeField] InventoryScript inventoryScript;
    [SerializeField] GameObject AngelIntroController;
    public bool AngelIntroEnable = false;
    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Dropped into inventory");
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            occupant = eventData.pointerDrag.GetComponent<DragDrop>();
            occupant.inSlot = true;
            occupant.slot = this;

            if (!((GameState.inventoryState.Contains(occupant.word)) || (occupant.word.Equals("New Text"))))
            {
                occupant.gameObject.transform.SetParent(this.gameObject.transform, false);
                inventoryScript.Add(occupant.word);
                
                occupant.canvasGroup.blocksRaycasts = true;
                occupant.canvasGroup.alpha = 1f;
            }
        }
        if (AngelIntroController != null && AngelIntroEnable)
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
