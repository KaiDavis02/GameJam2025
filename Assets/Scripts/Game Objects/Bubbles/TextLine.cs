using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLine : MonoBehaviour
{
    public int maxLength = 40;
    public float width = 0;
    [SerializeField] HorizontalLayoutGroup group;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addStuff(GameObject o)
    {
        o.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
        //o.transform.parent = transform;
        width += o.GetComponent<RectTransform>().rect.width;
    }

    public bool spaceToAdd(GameObject o)
    {
        if (width + o.GetComponent<RectTransform>().rect.width < maxLength)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
