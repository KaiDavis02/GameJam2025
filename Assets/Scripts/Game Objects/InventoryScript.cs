using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public HorizontalLayoutGroup horizontalLayoutGroup;
    public GameObject dragable;

    // list of word object in inventory
    private List<string> words = new List<string>();
    private int listPosition = 0;

    void SetWords()
    {
        // clear layoutgroup
         foreach (Transform child in horizontalLayoutGroup.transform)
            {
                Destroy(child.gameObject); // Delete the child object
            }

            // add new gameobjects for the words to disply
    }
    
    void Add()
    {

    }

    void Take()
    {

    }

    public void ScrollLeft()
    {

    }

    public void ScrollRight()
    {

    }
}
