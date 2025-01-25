using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] HorizontalLayoutGroup horizontalLayoutGroup;
    [SerializeField] GameObject dragable;

    // list of word object in inventory
    private List<Word> words = new List<Word>();
    private int listPosition = 0;

    [SerializeField] GameObject scrollRightObj;
    [SerializeField] GameObject scrollLeftObj;

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
            for (int i = listPosition; i < listPosition + 3; i++)
            {
                if (i < words.Count){
                FillInventory(words[i]);
                }
            }
    }

    void FillInventory(Word word)
    {
        GameObject newObject = Instantiate(dragable);
        newObject.transform.SetParent(horizontalLayoutGroup.transform, false);
        LayoutRebuilder.ForceRebuildLayoutImmediate(horizontalLayoutGroup.GetComponent<RectTransform>());
    }
    
    public void Add(Word word)
    {
        //Debug.Log("Adding " + word.text + " to inventory");
        words.Add(word);

        // if listposition * 3 or less words in list, call fill inventory
        if (words.Count <= listPosition + 3) 
        {
            FillInventory(word);
        } else {
            scrollRightObj.SetActive(true);
        }
    }

    public void Take(Word word)
    {
        //Debug.Log("Removing "+ word.text + " from inventory");
        words.Remove(word);
        SetWords();
    }

    public void ScrollLeft()
    {
        listPosition -= 3;
        SetWords();
        
        if (listPosition == 0){
            scrollLeftObj.SetActive(false);
        }

        scrollRightObj.SetActive(true);
    }

    public void ScrollRight()
    {
        listPosition += 3;
        SetWords();
        
        if (words.Count < listPosition + 3){
            scrollRightObj.SetActive(false);
        }

        scrollLeftObj.SetActive(true);
    }
}
