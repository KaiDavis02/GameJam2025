using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public Bubble bubble;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject slot;
    [SerializeField] VerticalLayoutGroup group;
    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponentInChildren<TextMeshProUGUI>();
        //Debug.Log(text.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void writeText()
    {
        // Read text until find [SLOT]
        // Break up into parts - Create new text meshes for each part?
        // put slots between parts

        string[] words = bubble.text.Split(" ");
        List<List<string>> textList = new List<List<string>>();
        List<string> l1 = new List<string>();
        textList.Add(l1);
        int index = 0;
        foreach (string w in words)
        {
            if (w.Equals("[SLOT]"))
            {
                List<string> l = new List<string>();
                textList.Add(l);
                index++;
            }
            else
            {
                textList[index].Add(w);
            }
        }


        //text.text = bubble.text;
    }
}
