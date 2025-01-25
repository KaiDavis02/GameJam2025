using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour, IController
{
    [SerializeField] GameObject speechBubblePrefab;
    [SerializeField] GameObject draggablePrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject door;

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
        testBub.GetComponent<SpeechBubble>().Controller = this.gameObject;

        makeTestFilledBubble();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void makeTestFilledBubble()
    {

        Problem newP = Initiator.genProblemTV();

        Bubble b = newP.bubblesLeft[newP.leftIndex];

        GameObject newBub = Instantiate(speechBubblePrefab, canvas.transform);
        newBub.GetComponent<SpeechBubble>().bubble = b;
        newBub.GetComponent<SpeechBubble>().writeText();
        newBub.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);

        GameObject dragabble = Instantiate(draggablePrefab, canvas.transform);
        newBub.GetComponent<SpeechBubble>().addToSlot(1, dragabble.GetComponent<DragDrop>());
        newBub.GetComponent<SpeechBubble>().Controller = this.gameObject;
    }
    public void checkComplete()
    {
        if (p.isSolved() != 0)
        {
            Debug.Log("Puzzle solved");
            door.GetComponent<Door>().locked = false;
        }
    }
}
