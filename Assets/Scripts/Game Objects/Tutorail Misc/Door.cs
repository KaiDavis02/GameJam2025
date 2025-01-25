using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IPointerClickHandler
{
    public bool locked = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!locked)
        {
            SceneManager.LoadScene("Outside");
        }
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
