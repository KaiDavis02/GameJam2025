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

        b1.text = "I found the [SLOT] over here";
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
        p.bubblesLeft = bs;
        Word w = new Word();
        w.text = "News";

        b.text = "ABC [SLOT] at 10";

        return p;
    }
    public static Problem genProblemLitter()
    {
        Problem p = new Problem();
        Bubble b = new Bubble();
        b.text = "Is that guy [SLOT]";
        Word w = new Word();
        w.text = "Littering";
        List<Bubble> bs = new List<Bubble>();
        bs.Add(b);
        b.noOfSlots = 1;
        b.word1 = w;
        p.bubblesLeft = bs;

        return p;
    }
    public static Problem genProblemGirlfriend()
    {
        Problem p = new Problem();
        Bubble b = new Bubble();
        List<Bubble> bs = new List<Bubble>();
        b.text = "I wish I had a [SLOT]";

        Word w = new Word();
        w.text = "Girlfriend";
        b.noOfSlots = 1;
        b.word1 = w;

        return p;
    }
    public static Problem genProblemJob()
    {
        Problem p = new Problem();
        Bubble b1 = new Bubble();
        Bubble b2 = new Bubble();
        b2.noOfSlots = 0;
        b1.noOfSlots = 1;

        b1.text = "Did you hear the [SLOT}";

        List<Bubble> bsLeft = new List<Bubble>();
        List<Bubble> bsRight = new List<Bubble>();

        List<List<string>> soltns = new List<List<string>>();
        List<string> s1 = new List<string>();
        soltns.Add(s1);
        s1.Add("News");
        b1.solutions = soltns;


        bsLeft.Add(b1);
        bsRight.Add(b2);

        Bubble b3 = new Bubble();
        b3.text = "Yeah, something about the [SLOT] market, right?";
        b3.noOfSlots = 1;
        Word w = new Word();
        w.text = "Job";
        b3.word1 = w;

        bsRight.Add(b3);

        p.bubblesLeft = bsLeft;
        p.bubblesRight = bsRight;

        return p;
    }
    public static Problem genProblemCat()
    {
        Problem p = new Problem();
        Bubble b1 = new Bubble();
        Bubble b2 = new Bubble();

        b1.text = "I think I saw a [SLOT]";
        Word w1 = new Word();
        w1.text = "Cat";
        b1.word1 = w1;

        b2.text = "Stop acting like a [SLOT]";
        Word w2 = new Word();
        w2.text = "Child";
        b2.word1 = w2;

        List<Bubble> bsLeft = new List<Bubble>();
        List<Bubble> bsRight = new List<Bubble>();

        bsLeft.Add(b1);
        bsRight.Add(b2);

        p.bubblesLeft = bsLeft;
        p.bubblesRight = bsRight;

        return p;

    }
    public static Problem genProblemPlane()
    {
        Problem p = new Problem();
        Bubble b1 = new Bubble();
        Bubble b2 = new Bubble();

        List<Bubble> bsLeft = new List<Bubble>();
        List<Bubble> bsRight = new List<Bubble>();

        bsLeft.Add(b1);
        bsRight.Add(b2);

        p.bubblesLeft = bsLeft;
        p.bubblesRight = bsRight;

        b1.text = "I [SLOT] planes!";
        b2.text = "Plants are [SLOT]";

        Word w1 = new Word();
        w1.text = "Like";
        Word w2 = new Word();
        w2.text = "Life";

        b1.word1 = w1;
        b2.word1 = w2;

        return p;
    }

    public static Problem generateCouple()
    {
        Problem p = new Problem();
        Bubble b1L = new Bubble();
        Bubble b2L = new Bubble();
        Bubble b1R = new Bubble();
        Bubble b2R = new Bubble();
        Bubble b3L = new Bubble();

        List<Bubble> bsLeft = new List<Bubble>();
        List<Bubble> bsRight = new List<Bubble>();

        bsLeft.Add(b1L); bsLeft.Add(b2L); bsLeft.Add(b3L);
        bsRight.Add(b1R); bsRight.Add(b2R);

        b1L.text = "Who's Sarah!";
        b1L.noOfSlots = 0;
        b1R.text = "She's just my [SLOT]";
        b1R.noOfSlots = 1;

        List<List<string>> soltn = new List<List<string>>();
        List<string> s11 = new List<string>();
        List<string> s12 = new List<string>();
        s11.Add("Cat");
        s12.Add("Girlfriend");
        soltn.Add(s11); soltn.Add(s12);
        b1R.solutions = soltn;

        b2L.text = "YOUR WHAT! We're getting divorced!";
        b2L.noOfSlots = 0;

        b3L.text = "I really [SLOT] pets!";
        List<List<string>> soltns2 = new List<List<string>>();
        List<string> s21 = new List<string>();
        s21.Add("Like");
        soltns2.Add(s21);
        b3L.solutions = soltns2;
        b3L.noOfSlots = 1;

        b2R.text = "Let's get married!";
        b2R.noOfSlots = 0;

        p.bubblesLeft = bsLeft;
        p.bubblesRight = bsRight;

        return p;
    }

    public static Problem genChruch1()
    {
        Problem p = new Problem();
        Bubble b1L = new Bubble();
        Bubble b1R = new Bubble();
        Bubble b2L = new Bubble();
        Bubble b3L = new Bubble();

        List<Bubble> bsLeft = new List<Bubble>();
        List<Bubble> bsRight = new List<Bubble>();

        p.bubblesLeft = bsLeft;
        p.bubblesRight = bsRight;

        bsLeft.Add(b1L); bsLeft.Add(b2L); bsLeft.Add(b3L);
        bsRight.Add(b1R); 

        b1R.text = "Should I get a new [SLOT]";
        b1L.text = "";
        b1L.noOfSlots = 0;
        b2L.text = "Do what brings you [SLOT]";
        b2L.noOfSlots = 1;
        b3L.text = "That's just [SLOT]";
        b3L.noOfSlots = 1;

        Word w1 = new Word();
        w1.text = "Joy";
        Word w2 = new Word();
        w2.text = "Evil";

        b2L.word1 = w1;
        b3L.word1 = w2;

        List<List<string>> soltn = new List<List<string>>();
        List<string> s1 = new List<string>();
        List<string> s2 = new List<string>();
        soltn.Add(s1); soltn.Add(s2);
        s1.Add("Job"); s2.Add("Child");

        b1R.solutions = soltn;


        return p;
    }
    public static Problem genChruch2()
    {
        Problem p = new Problem();
        Bubble b1L = new Bubble();
        Bubble b1R = new Bubble();
        Bubble b2L = new Bubble();
        Bubble b3L = new Bubble();

        List<Bubble> bsLeft = new List<Bubble>();
        List<Bubble> bsRight = new List<Bubble>();

        p.bubblesLeft = bsLeft;
        p.bubblesRight = bsRight;

        bsLeft.Add(b1L); bsLeft.Add(b2L); bsLeft.Add(b3L);
        bsRight.Add(b1R);

        b1R.text = "What is the meaning of [SLOT]";
        b1L.text = "";
        b1L.noOfSlots = 0;
        b2L.text = "To have [SLOT] and make games";
        b2L.noOfSlots = 1;
        b3L.text = "Something that causes [SLOT]";
        b3L.noOfSlots = 1;

        Word w1 = new Word();
        w1.text = "Fun";
        Word w2 = new Word();
        w2.text = "Pain";

        b2L.word1 = w1;
        b3L.word1 = w2;

        List<List<string>> soltn = new List<List<string>>();
        List<string> s1 = new List<string>();
        List<string> s2 = new List<string>();
        soltn.Add(s1); soltn.Add(s2);
        s1.Add("Life"); s2.Add("Evil");

        b1R.solutions = soltn;

        return p;
    }
}
