using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public HorizontalLayoutGroup horizontalLayoutGroup;
    public GameObject dragable;

    // list of word object in inventory
    private List<Word> words = new List<Word>();
    private int listPosition = 0;

    public GameObject scrollRightObj;
    public GameObject scrollLeftObj;

    // Start is called before the first frame update
    void Start()
    {
        scrollLeftObj.SetActive(false);
        scrollRightObj.SetActive(false);
    }

    void SetWords()
    {
        // clear layoutgroup
         foreach (Transform child in horizontalLayoutGroup.transform)
            {
                Destroy(child.gameObject); // Delete the child object
            }
        
            // add new gameobjects for the words to disply
    }

    void FillInventory(Word word)
    {
        GameObject newObject = Instantiate(dragable);
        newObject.transform.SetParent(horizontalLayoutGroup.transform, false);
        LayoutRebuilder.ForceRebuildLayoutImmediate(horizontalLayoutGroup.GetComponent<RectTransform>());
    }
    
    public void Add(Word word)
    {
        Debug.Log("Adding " + word+ " to inventory");
        words.Add(word);

        // if 3 or less words in list, call fill inventory
        if (words.Count <= 3) 
        {
            FillInventory(word);
        }
    }

    public void Take(Word word)
    {
        Debug.Log("Removing "+ word+ " from inventory");
        words.Remove(word);
    }

    public void ScrollLeft()
    {

    }

    public void ScrollRight()
    {

    }
}
