using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState 
{
    // save inventory state
    public static List<Word> inventoryState = new List<Word>();
    public static int inventoryPosition = 0;

    // save alleyway word state
    public static bool hateAquired = false;
    public static bool evilAquired = false;
    public static bool painAquired = false;

    public static bool loveAquired = false;
    public static bool joyAquired = false;
    public static bool funAquired = false;

    // save the sate of all the problems in the game

    // controllers should access this every time they are loaded

    public static Problem tutorialProblem;
    public static Problem maritalProblem;


    public static Problem church1;
    public static Problem church2;

    public static Problem devilProblem;

    public static Problem trialProblem;

    public static Problem catProblem;
    public static Problem planeProblem;
    public static Problem jobProblem;
    public static Problem tvProblem;
    public static Problem gfProblem;
    public static Problem litterProblem;

    public static Problem sideProblemChurch;
    public static Problem sideProblemCourt;
    
    public static Problem debugProblem;
    public static void enterTutorial()
    {
        
            tutorialProblem = Initiator.genProblemTutorial();
        
    }
    public static void genDebugProblem()
    {
        debugProblem = Initiator.genProblemTutorial();
    }

    public static void start()
    {
        tutorialProblem = Initiator.genProblemTutorial();
        tvProblem = Initiator.genProblemTV();

        catProblem = Initiator.genProblemCat();
        planeProblem = Initiator.genProblemPlane();
        gfProblem = Initiator.genProblemGirlfriend();

        maritalProblem = Initiator.generateCouple();
        litterProblem = Initiator.genProblemLitter();

        church1 = Initiator.genChruch1();
        church2 = Initiator.genChruch2();
    }
}
