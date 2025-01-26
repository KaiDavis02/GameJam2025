using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road2Controller : MonoBehaviour
{
    [SerializeField] GameObject speechBubblePrefab;
    [SerializeField] GameObject canvas;
    GameObject speech1;
    GameObject speech2;
    GameObject speech3;
    GameObject speech4;
    [SerializeField] GameObject draggablePrefab;

    Problem cat;
    Problem plane;
    // Start is called before the first frame update
    void Start()
    {
        cat = GameState.catProblem;
        plane = GameState.planeProblem;

        //TEST
        loadProblem1(cat);
        loadProblem2(plane);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loadProblem1(Problem p)
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
    void loadProblem2(Problem p)
    {
        Bubble bL = p.bubblesLeft[p.leftIndex];
        Bubble bR = p.bubblesRight[p.rightIndex];

        GameObject speech3 = Instantiate(speechBubblePrefab, canvas.transform);
        GameObject speech4 = Instantiate(speechBubblePrefab, canvas.transform);

        speech3.GetComponent<RectTransform>().position = new Vector3(5, 2.5f, 0);
        speech4.GetComponent<RectTransform>().position = new Vector3(2, 2.5f, 0);

        speech3.GetComponent<SpeechBubble>().bubble = bL;
        speech4.GetComponent<SpeechBubble>().bubble = bR;

        speech3.GetComponent<SpeechBubble>().writeText();
        speech4.GetComponent<SpeechBubble>().writeText();

        speech3.GetComponent<SpeechBubble>().Controller = this.gameObject;
        speech4.GetComponent<SpeechBubble>().Controller = this.gameObject;

        if (bL.word1 != null)
        {
            Debug.Log("IT HAS A WORD");
            GameObject dragabble = Instantiate(draggablePrefab, canvas.transform);
            dragabble.GetComponent<DragDrop>().SetWord(bL.word1);
            speech3.GetComponent<SpeechBubble>().addToSlot(1, dragabble.GetComponent<DragDrop>());
        }
        if (bR.word1 != null)
        {
            Debug.Log("IT HAS A WORD");
            GameObject dragabble = Instantiate(draggablePrefab, canvas.transform);
            dragabble.GetComponent<DragDrop>().SetWord(bR.word1);
            speech4.GetComponent<SpeechBubble>().addToSlot(1, dragabble.GetComponent<DragDrop>());
        }
    }
}
