using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour, IController
{
    public SpeechBubble bubble;
    public DropSlot slot;

    public void checkComplete()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        bubble.Controller = this.gameObject;
        slot.AddOnWordChangedEvent(OnSlotChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSlotChanged(string word)
    {
        Debug.Log("User selected word: " + word);
        if (word.Equals("Start"))
        {
            SceneManager.LoadScene("AngelIntro");
        }
        else if (word.Equals("Exit"))
        {
            // For Unity Editor
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else
        {
            Debug.Log("Unrecognised word: " + word);
        }
    }
}
