using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] GameObject speechBubblePrefab;
    [SerializeField] GameObject draggablePrefab;
    [SerializeField] Canvas canvas;

    Problem p;
    // Start is called before the first frame update
    void Start()
    {
        GameState.enterTutorial();
        p = GameState.tutorialProblem;

        GameObject testBub = Instantiate(speechBubblePrefab, canvas.transform);
        GameState.genDebugProblem();
        p = GameState.debugProblem;

        Debug.Log(p.leftIndex);
        Debug.Log(p.bubblesLeft[p.leftIndex].text);

        testBub.GetComponent<SpeechBubble>().bubble = p.bubblesLeft[p.leftIndex];
        testBub.GetComponent<SpeechBubble>().writeText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
