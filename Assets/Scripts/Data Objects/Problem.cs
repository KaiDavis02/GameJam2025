using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem 
{
    public List<Bubble> bubblesLeft;
    public List<Bubble> bubblesRight;
    public int leftIndex = 0;
    public int rightIndex = 0;


    // THIS MEANS WHETHER IT IS A MAIN PROBLEM (One to solve)
    // OR A PROBLEM TO JUST GIVE YOU WORDS
    // Side problems only have a left array
    public bool sideProblem;

    public Bubble getNextLeft()
    {
        Bubble b = bubblesLeft[leftIndex];
        leftIndex++;
        return (b);
    }
    public Bubble getNextRight()
    {
        Bubble b = bubblesRight[rightIndex];
        rightIndex++;
        return (b);
    }
    public int isSolved()
    {
        // if the right does not need a solution
        if (bubblesRight[rightIndex].noOfSlots == 0)
        {
            return bubblesLeft[leftIndex].isSolved();
        }
        // if the left does not need a solution
        else if (bubblesLeft[leftIndex].noOfSlots ==0)
        {
            return bubblesRight[rightIndex].isSolved();
        }
        // if both are filled with the same solution
        else if (bubblesLeft[leftIndex].isSolved() == bubblesRight[rightIndex].isSolved())
        {
            return bubblesRight[rightIndex].isSolved();
        }
        else
        {
            return 0;
        }
    }
}
