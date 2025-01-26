using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble 
{
    public int solutionID;
    // Solution ID
    // Basically stores which solution this bubble is solved for
    // let's say that there are 2 bubbles in this problem
    // bubble 1 is solved by the word key or hammer, with IDs 1 and 2
    // bubble 2 is solved by the word door or window, with IDs 1 and 2
    // both bubbles have to have the same solution ID for the puzzle to be solved
    // so either it's solution 1, key and door, or solution 2, hammer and window, not key and window or hammer and door
    public int noOfSlots;
    public List<List<string>> solutions;
    public List<string> wordsInside;

    public Word word1;
    public Word word2;
    public Word word3;

    // in this text the position of the slot will be shown by [SLOT]
    // we need to figure out how to get this to work later.
    public string text;

    // turns the individual words into the list used for comparison
    public void generateWordList()
    {
        wordsInside = new List<string>();
        if (word1 != null && word1.text != "")
        {
            wordsInside.Add(word1.text);
        }
        if (word2 != null && word2.text != "")
        {
            wordsInside.Add(word2.text);
        }
        if (word3 != null && word3.text != "")
        {
            wordsInside.Add(word3.text);
        }
    }


    public int isSolved()
    {
        generateWordList();
        int index = 0;
        foreach(List<string> l in solutions)
        {
            index++;
            Debug.Log("Comparing to solution: " + index);
            if (compareLists(l, wordsInside))
            {
                Debug.Log("Returning: " + index);
                return index;
            }
        }
        return 0;
    }
    public bool compareLists(List<string> list1, List<string> list2)
    {
        bool equal = true;
        if (list1.Count == list2.Count)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                Debug.Log("Word for solution:");
                Debug.Log(list1[i]);
                Debug.Log("Word in bubble");
                Debug.Log(list2[i]);
                if (list1[i].Equals(list2[i]))
                {

                }
                else
                {
                    equal = false;
                }
            }
        }
        else
        {
            equal = false;
        }
        Debug.Log(equal);
        return equal;
    }

}
