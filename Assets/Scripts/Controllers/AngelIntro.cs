using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngelIntro : MonoBehaviour
{
    [SerializeField] InventoryScript inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void done()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
