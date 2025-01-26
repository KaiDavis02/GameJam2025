using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road1Controller : MonoBehaviour, IController
{
    Problem coupleProblem;
    [SerializeField] GameObject speechBubblePrefab;
    [SerializeField] GameObject canvas;
    GameObject speech1;
    GameObject speech2;
    [SerializeField] GameObject draggablePrefab;
    public void checkComplete()
    {
        // check if couple problem is solved
        if (coupleProblem.isSolved() == 1)
        {
            // if the problem has is on it's first part
            // with both ifs, if the first problem has just been solved with solution 1
            if (coupleProblem.state == 0)
            {
                coupleProblem.state = 1;
                coupleProblem.leftIndex = 2;
                coupleProblem.rightIndex = 0;
            }
            else if (coupleProblem.state == 1)
            {
                coupleProblem.state = 2;
                coupleProblem.rightIndex = 1;
            }
            removeBubs();
            loadProblem(coupleProblem);
        }
        else if(coupleProblem.isSolved() == 2)
        {
            if (coupleProblem.state == 0)
            {
                //using 6 as the bad ending
                coupleProblem.state = 6;
                coupleProblem.leftIndex = 1;
            }
            removeBubs();
            loadProblem(coupleProblem);
        }
        Debug.Log(coupleProblem.state);
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        coupleProblem = GameState.maritalProblem;
        loadProblem(coupleProblem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loadProblem(Problem p)
    {
        Bubble bL = p.bubblesLeft[p.leftIndex];
        Bubble bR = p.bubblesRight[p.rightIndex];

        GameObject speech1 = Instantiate(speechBubblePrefab, canvas.transform);
        GameObject speech2 = Instantiate(speechBubblePrefab, canvas.transform);

        speech1.GetComponent<RectTransform>().position = new Vector3(-5, 2, 0);
        speech2.GetComponent<RectTransform>().position = new Vector3(-2, 2, 0);

        speech1.GetComponent<SpeechBubble>().bubble = bL;
        speech2.GetComponent<SpeechBubble>().bubble = bR;

        speech1.GetComponent<SpeechBubble>().writeText();
        speech2.GetComponent<SpeechBubble>().writeText();

        speech1.GetComponent<SpeechBubble>().Controller = this.gameObject;
        speech2.GetComponent<SpeechBubble>().Controller = this.gameObject;

        if (bL.word1 != null && bL.word1.text != "")
        {
            Debug.Log("IT HAS A WORD " + bL.word1.text);
            GameObject dragabble = Instantiate(draggablePrefab, canvas.transform);
            dragabble.GetComponent<DragDrop>().SetWord(bL.word1);
            speech1.GetComponent<SpeechBubble>().addToSlot(1, dragabble.GetComponent<DragDrop>());
        }
        if (bR.word1 != null && bR.word1.text != "")
        {
            Debug.Log("IT HAS A WORD");
            GameObject dragabble = Instantiate(draggablePrefab, canvas.transform);
            dragabble.GetComponent<DragDrop>().SetWord(bR.word1);
            speech2.GetComponent<SpeechBubble>().addToSlot(1, dragabble.GetComponent<DragDrop>());
        }
    }
    void removeBubs()
    {
        Destroy(speech1);
        Destroy(speech2);
    }
}
