using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Church1Controller : MonoBehaviour, IController
{
    [SerializeField] GameObject speechBubblePrefab;
    [SerializeField] GameObject canvas;
    GameObject speech1;
    GameObject speech2;
    Problem chruch1Prob;
    public void checkComplete()
    {
        //state 0, start
        // state 1, gave job as answer
        // state 6, gave child as answer
        if (chruch1Prob.isSolved() == 1)
        {
            if (chruch1Prob.state == 0)
            {
                chruch1Prob.state = 1;
                chruch1Prob.rightIndex = 1;
            }
            else if(chruch1Prob.state == 1)
            {

            }
            removeBubs();
            loadProblem(chruch1Prob);
        }
        else if (chruch1Prob.isSolved() == 2)
        {
            if (chruch1Prob.state == 0)
            {
                chruch1Prob.state = 6;
                chruch1Prob.rightIndex = 2;
            }
            else if (chruch1Prob.state == 6)
            {

            }
            removeBubs();
            loadProblem(chruch1Prob);
        }
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        //DEBUG
        GameState.start();
        //DEBUG
        chruch1Prob = GameState.church1;
        loadProblem(chruch1Prob);
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
    }
    void removeBubs()
    {
        Destroy(speech1);
        Destroy(speech2);
    }
}
