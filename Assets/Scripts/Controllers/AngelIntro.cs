using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngelIntro : MonoBehaviour
{
    [SerializeField] InventoryScript inventory;
    public string sceneName = "";
    
    public void done()
    {
        SceneManager.LoadScene(sceneName);
    }
}
