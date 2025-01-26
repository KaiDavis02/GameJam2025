using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState 
{
    // save inventory state
    public static List<Word> inventoryState = new List<Word>();
    public static int inventoryPosition = 0;

    // save the sate of all the problems in the game

    // controllers should access this every time they are loaded

    public static Problem tutorialProblem;
    public static Problem maritalProblem;


    public static Problem confessionProblem;

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
    }
}
