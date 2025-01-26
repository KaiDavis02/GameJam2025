using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SubmitWordScript : DropSlot
{
    public string word;
    [SerializeField] GameObject acquiredWord;
    [SerializeField] GameObject finalWord;
    bool evil;
    
    // Start is called before the first frame update
    void Start()
    {
        bool wordAcquired = false;

        switch (word)
        {
            case "hate":
            {
                evil = true;
                wordAcquired = GameState.hateAquired;
                break;
            }
            case "evil":
            {
                evil = true;
                wordAcquired = GameState.evilAquired;
                break;
            }
            case "pain":
            {
                evil = true;
                wordAcquired = GameState.painAquired;
                break;
            }

            case "love":
            {
                evil = false;
                wordAcquired = GameState.loveAquired;
                break;
            }
            case "joy":
            {
                evil = false;
                wordAcquired = GameState.joyAquired;
                break;
            }
            case "fun":
            {
                evil = false;
                wordAcquired = GameState.funAquired;
                break;
            }
        }

        if (wordAcquired)
        {
            acquiredWord.SetActive(true);
        }
    }

    public void WordAcquired()
    {
        switch (word)
        {
            case "hate":
            {
                GameState.hateAquired = true;
                break;
            }
            case "evil":
            {
                GameState.evilAquired = true;
                break;
            }
            case "pain":
            {
                GameState.painAquired = true;
                break;
            }

            case "love":
            {
                GameState.loveAquired = true;
                break;
            }
            case "joy":
            {
                GameState.joyAquired = true;
                break;
            }
            case "fun":
            {
                GameState.funAquired = true;
                break;
            }
        }
    }

    public void checkAllWords()
    {
        if (evil)
        {
            if (GameState.hateAquired && GameState.evilAquired && GameState.painAquired)
            {
                finalWord.SetActive(true);
            }
        }
        else
        {
            if (GameState.loveAquired && GameState.joyAquired && GameState.funAquired)
            {
                finalWord.SetActive(true);
            }
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            occupant = eventData.pointerDrag.GetComponent<DragDrop>();

            if (occupant.word.text.Equals(word))
            {
                WordAcquired();
                Destroy(occupant.gameObject);
                acquiredWord.SetActive(true);
                checkAllWords();
            }
        }
    }
}
