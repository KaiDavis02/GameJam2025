using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{

    [SerializeField] GameObject Bubble1;
    SpeechBubble testBub;
    Problem p;
    [SerializeField] TextLine testLine;
    [SerializeField] GameObject testText;
    [SerializeField] GameObject testText2;
    [SerializeField] GameObject testSlot;
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

        testLine.addStuff(testText);
        testLine.addStuff(testSlot);
        testLine.addStuff(testText2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
