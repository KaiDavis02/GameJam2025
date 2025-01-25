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

    public string word1;
    public string word2;
    public string word3;

    // turns the individual words into the list used for comparison
    public void generateWordList()
    {
        wordsInside = new List<string>();
        if (word1 != "")
        {
            wordsInside.Add(word1);
        }
        if (word2 != "")
        {
            wordsInside.Add(word2);
        }
        if (word2 != "")
        {
            wordsInside.Add(word2);
        }
    }


    public int isSolved()
    {
        int index = 0;
        foreach(List<string> l in solutions)
        {
            index++;
            if (compareLists(l, wordsInside))
            {
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
        return equal;
    }

}
