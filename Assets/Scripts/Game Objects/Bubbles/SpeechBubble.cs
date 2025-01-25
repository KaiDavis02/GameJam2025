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
    [SerializeField] GameObject TextLinePrefab;
    [SerializeField] GameObject AdjustText;


    public GameObject Controller;


    List<DropSlot> slots;
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
        // Split sentence into parts
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
        List<GameObject> lines = new List<GameObject>();
        GameObject line1 = Instantiate(TextLinePrefab, transform);
        line1.GetComponent<TextLine>().maxLength = GetComponent<RectTransform>().rect.width;
        lines.Add(line1);

        int lineIndex = 0;
        int listIndex = 1;

        slots = new List<DropSlot>();

        foreach (List<string> l in textList)
        {
            string someWords = "";
            foreach (string s in l)
            {
                someWords += s;
                someWords += " ";
            }
            GameObject textA = Instantiate(AdjustText, transform);
            textA.GetComponent<TextMeshProUGUI>().text = someWords;
            LayoutRebuilder.ForceRebuildLayoutImmediate(textA.GetComponent<RectTransform>());
            if (lines[lineIndex].GetComponent<TextLine>().spaceToAdd(textA))
            {
                lines[lineIndex].GetComponent<TextLine>().addStuff(textA);
            }
            else
            {
                GameObject newLine = Instantiate(TextLinePrefab, transform);
                lines.Add(newLine);
                lineIndex += 1;
                newLine.GetComponent<TextLine>().maxLength = GetComponent<RectTransform>().rect.width;
                newLine.GetComponent<TextLine>().addStuff(textA);
            }
            if (listIndex < textList.Count)
            {
                GameObject box = Instantiate(slot, transform);
                box.GetComponent<DropSlot>().speechBubble = this;
                box.GetComponent<DropSlot>().slotNo = listIndex;
                slots.Add(box.GetComponent<DropSlot>());
                if (lines[lineIndex].GetComponent<TextLine>().spaceToAdd(box))
                {
                    lines[lineIndex].GetComponent<TextLine>().addStuff(box);
                }
                else
                {
                    GameObject newLine = Instantiate(TextLinePrefab, transform);
                    lines.Add(newLine);
                    lineIndex += 1;
                    newLine.GetComponent<TextLine>().maxLength = GetComponent<RectTransform>().rect.width;
                    newLine.GetComponent<TextLine>().addStuff(box);
                }
            }
            listIndex++;
        }

        //text.text = bubble.text;
    }
    public void updateWords(Word w, int slotNo)
    {
        switch (slotNo)
        {
            case 1:
                bubble.word1 = w;
                break;
            case 2:
                bubble.word2 = w;
                break;
            case 3:
                bubble.word3 = w;
                break;
            default:
                break;
        }
        Controller.GetComponent<TestController>().checkComplete();
    }
    public void addToSlot(int slotNo, DragDrop dd)
    {
        slots[slotNo - 1].occupy(dd);
    }
}
