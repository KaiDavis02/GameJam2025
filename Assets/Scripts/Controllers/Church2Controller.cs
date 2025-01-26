using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church2Controller : MonoBehaviour
{
    [SerializeField] GameObject speechBubblePrefab;
    [SerializeField] GameObject canvas;
    GameObject speech1;
    GameObject speech2;
    Problem chruch2Prob;
    [SerializeField] GameObject draggablePrefab;
    public void checkComplete()
    {
        //state 0, start
        // state 1, gave job as answer
        // state 6, gave child as answer
        if (chruch2Prob.isSolved() == 1)
        {
            if (chruch2Prob.state == 0)
            {
                chruch2Prob.state = 1;
                chruch2Prob.rightIndex = 1;
            }
            else if (chruch2Prob.state == 1)
            {

            }
            removeBubs();
            loadProblem(chruch2Prob);
        }
        else if (chruch2Prob.isSolved() == 2)
        {
            if (chruch2Prob.state == 0)
            {
                chruch2Prob.state = 6;
                chruch2Prob.rightIndex = 2;
            }
            else if (chruch2Prob.state == 6)
            {

            }
            removeBubs();
            loadProblem(chruch2Prob);
        }
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        ////DEBUG
        //GameState.start();
        ////DEBUG
        chruch2Prob = GameState.church2;
        loadProblem(chruch2Prob);
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

        speech1.GetComponent<RectTransform>().position = new Vector3(5, 2, 0);
        speech2.GetComponent<RectTransform>().position = new Vector3(2, 2, 0);

        speech1.GetComponent<SpeechBubble>().bubble = bL;
        speech2.GetComponent<SpeechBubble>().bubble = bR;

        speech1.GetComponent<SpeechBubble>().writeText();
        speech2.GetComponent<SpeechBubble>().writeText();

        speech1.GetComponent<SpeechBubble>().Controller = this.gameObject;
        speech2.GetComponent<SpeechBubble>().Controller = this.gameObject;
        if (bL.word1 != null)
        {
            Debug.Log("IT HAS A WORD " + bL.word1.text);
            GameObject dragabble = Instantiate(draggablePrefab, canvas.transform);
            dragabble.GetComponent<DragDrop>().SetWord(bL.word1);
            speech1.GetComponent<SpeechBubble>().addToSlot(1, dragabble.GetComponent<DragDrop>());
        }
        if (bR.word1 != null)
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
