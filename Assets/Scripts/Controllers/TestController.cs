using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{

    [SerializeField] GameObject Bubble1;
    SpeechBubble testBub;
    Problem p;
    [SerializeField] GameObject bubblePrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject dragabblePrefab;

    // Start is called before the first frame update
    void Start()
    {
        testBub = Bubble1.GetComponent<SpeechBubble>();
        GameState.genDebugProblem();
        p = GameState.debugProblem;

        Debug.Log(p.leftIndex);
        Debug.Log(p.bubblesLeft[p.leftIndex].text);

        testBub.bubble = p.bubblesLeft[p.leftIndex];
        testBub.writeText();

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

        GameObject newBub = Instantiate(bubblePrefab, canvas.transform);
        newBub.GetComponent<SpeechBubble>().bubble = b;
        newBub.GetComponent<SpeechBubble>().writeText();
        newBub.GetComponent<RectTransform>().position = new Vector3(0, 0, 0);

        GameObject dragabble = Instantiate(dragabblePrefab, canvas.transform);
        newBub.GetComponent<SpeechBubble>().addToSlot(1, dragabble.GetComponent<DragDrop>());
        newBub.GetComponent<SpeechBubble>().Controller = this.gameObject;
    }

    public void checkComplete()
    {
        if (p.isSolved() != 0)
        {
            Debug.Log("Puzzle solved");
        }
    }

}
