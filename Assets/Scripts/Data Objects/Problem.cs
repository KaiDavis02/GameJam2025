using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem 
{
    public List<Bubble> bubblesLeft;
    public List<Bubble> bubblesRight;
    public int leftIndex = 0;
    public int rightIndex = 0;

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
        if (bubblesLeft[leftIndex].isSolved() == bubblesRight[rightIndex].isSolved())
        {
            return bubblesRight[rightIndex].isSolved();
        }
        else
        {
            return 0;
        }
    }
}
