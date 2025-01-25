using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLine : MonoBehaviour
{
    public float maxLength = 40;
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
        Debug.Log("width of new component");
        Debug.Log(o.GetComponent<RectTransform>().rect.width);
        o.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
        //o.transform.parent = transform;
        width += o.GetComponent<RectTransform>().rect.width;
        Debug.Log("adding width");
        Debug.Log(width);
    }

    public bool spaceToAdd(GameObject o)
    {
        if (width + o.GetComponent<RectTransform>().rect.width < maxLength)
        {
            Debug.Log(width);
            Debug.Log(maxLength);
            return true;
        }
        else
        {
            Debug.Log(width);
            return false;
        }
        
    }
}
