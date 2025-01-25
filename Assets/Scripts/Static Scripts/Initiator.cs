using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Initiator
{
    // make the problem data object for problem 1
    public static Problem genProblemTutorial()
    {
        // make new objects
        Problem p = new Problem();
        Bubble b1 = new Bubble();
        Bubble b2 = new Bubble();

        // assign the bubbles to the problem
        // if there were multiple parts to the problem, i.e. a person says something else
        // there would be more elements added to this list
        List<Bubble> left = new List<Bubble>();
        left.Add(b1);
        List<Bubble> right = new List<Bubble>();
        right.Add(b2);
        p.bubblesLeft = left;
        p.bubblesRight = right;

        b1.noOfSlots = 1;
        b2.noOfSlots = 0;

        b1.text = "I found the [SLOT] blah blah";
        b2.text = "I can't get out";


        // Add solutions for each bubble
        // b2 does not need to since it has 0 slots
        List<List<string>> leftSolutions = new List<List<string>>();
        List<string> solutionLeft1 = new List<string>();
        solutionLeft1.Add("Key");
        leftSolutions.Add(solutionLeft1);
        b1.solutions = leftSolutions;

        return p;
    }

    public static Problem genProblemTV()
    {
        Problem p = new Problem();
        p.sideProblem = true;
        Bubble b = new Bubble();
        List<Bubble> bs = new List<Bubble>();
        bs.Add(b);

        Word w = new Word();
        w.text = "News";

        b.text = "ABC [SLOT] at 10";

        return p;
    }
    public static Problem genProblem3()
    {
        Problem p = new Problem();
        return p;
    }
    public static Problem genProblem4()
    {
        Problem p = new Problem();
        return p;
    }
    public static Problem genProblem5()
    {
        Problem p = new Problem();
        return p;
    }
    public static Problem genProblem6()
    {
        Problem p = new Problem();
        return p;

    }
}
