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


    // Booleans to determine whether the puzzles need to be generated for the first time or not
    public static bool firstTutorial = true;
    // whether this one stays depends on whether we do outside as one scene or multiple
    public static bool firstOutside = true;
    public static bool firstChruch = true;
    public static bool firstDevil = true;
    public static bool firstCourt = true;

    public static Problem tutorialProblem;
    public static Problem maritalProblem;
    public static Problem confessionProblem;
    public static Problem devilProblem;
    public static Problem trialProblem;

    public static Problem sideProblemOutside1;
    public static Problem sideProblemOutside2;
    public static Problem sideProblemOutside3;

    public static Problem sideProblemChurch;
    public static Problem sideProblemCourt;
    public static Problem sideProblemTutorial;
    public static Problem debugProblem;
    public static void enterTutorial()
    {
        if (firstTutorial)
        {
            firstTutorial = false;
            tutorialProblem = Initiator.genProblemTutorial();
        }
    }
    public static void genDebugProblem()
    {
        debugProblem = Initiator.genProblemTutorial();
    }
}
