using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] HorizontalLayoutGroup horizontalLayoutGroup;
    [SerializeField] GameObject dragable;
    [SerializeField] GameObject scrollRightObj;
    [SerializeField] GameObject scrollLeftObj;

    // Start is called before the first frame update
    void Start()
    {
        scrollLeftObj.SetActive(false);
        scrollRightObj.SetActive(false);

        foreach (Word word in GameState.inventoryState)
        {
            GameObject newObject = Instantiate(dragable);
            DragDrop dragDropScript = newObject.GetComponent<DragDrop>();
            dragDropScript.SetWord(word);
            newObject.transform.SetParent(horizontalLayoutGroup.transform, false);
        }
        SetWords();
    }

    void SetWords()
    {
        Debug.Log("Called setwords");
        // disable gameobjects in layoutgroup apart from those to be viewed
        foreach (Transform child in horizontalLayoutGroup.transform)
        {
            GameObject childGameObject = child.gameObject;
            DragDrop dragDropScript = childGameObject.GetComponent<DragDrop>();
            int index = GameState.inventoryState.IndexOf(dragDropScript.word);
            if (index >= GameState.inventoryPosition && index < GameState.inventoryPosition + 3)
            {
                childGameObject.SetActive(true);
            } else {
                childGameObject.SetActive(false);
            }
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(horizontalLayoutGroup.GetComponent<RectTransform>());
    }
    
    public void Add(Word word)
    {
        //Debug.Log("Adding " + word.text + " to inventory");
        GameState.inventoryState.Add(word);

        Debug.Log("GameState.inventoryState.count: " + GameState.inventoryState.Count + "         GameState.inventoryPosition: "+ GameState.inventoryPosition);
        if (GameState.inventoryState.Count > GameState.inventoryPosition + 3)
        {
            scrollRightObj.SetActive(true);
        }

        SetWords();
    }

    public void Take(Word word)
    {
        //Debug.Log("Removing "+ word.text + " from inventory");
        GameState.inventoryState.Remove(word);

        SetWords();
        
        if (GameState.inventoryState.Count <= GameState.inventoryPosition + 3) {
            scrollRightObj.SetActive(false);
        }
    }

    public void ScrollLeft()
    {
        GameState.inventoryPosition -= 3;
        SetWords();
        
        if (GameState.inventoryPosition == 0){
            scrollLeftObj.SetActive(false);
        }

        scrollRightObj.SetActive(true);
    }

    public void ScrollRight()
    {
        GameState.inventoryPosition += 3;
        SetWords();
        
        if (GameState.inventoryState.Count < GameState.inventoryPosition + 3){
            scrollRightObj.SetActive(false);
        }

        scrollLeftObj.SetActive(true);
    }
}
