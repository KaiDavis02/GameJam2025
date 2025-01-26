using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour, IController
{
    [SerializeField] GameObject speechBubblePrefab;
    [SerializeField] GameObject draggablePrefab;
    [SerializeField] Canvas canvas;
    bool locked = true;

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
        testBub.GetComponent<RectTransform>().position = new Vector3(-5, 2, 0);


        GameObject bubble2 = Instantiate(speechBubblePrefab, canvas.transform);
        bubble2.GetComponent<SpeechBubble>().bubble = p.bubblesRight[p.rightIndex];
        bubble2.GetComponent<SpeechBubble>().writeText();
        bubble2.GetComponent<SpeechBubble>().Controller = this.gameObject;
        bubble2.GetComponent<RectTransform>().position = new Vector3(5, 2, 0);

        //makeTestFilledBubble();
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
            locked = false;
        }
    }
    public void door()
    {
        if (!locked)
        {
            SceneManager.LoadScene("Road1");
        }
    }
}
