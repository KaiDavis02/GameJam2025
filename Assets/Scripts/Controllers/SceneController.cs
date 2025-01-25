using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

    public void ToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
 
    public void ToRoad1()
    {
        SceneManager.LoadScene("Road1");
    }

    public void ToRoad2()
    {
        SceneManager.LoadScene("Road2");
    }

    public void ToRoad3()
    {
        SceneManager.LoadScene("Road3");
    }

    public void ToAngelAlley()
    {
        SceneManager.LoadScene("AngelAlley");
    }

    public void ToDevilAlley()
    {
        SceneManager.LoadScene("DevilAlley");
    }

    public void ToChurch1()
    {
        SceneManager.LoadScene("Church1");
    }

    public void ToChurch2()
    {
        SceneManager.LoadScene("Church2");
    }

    public void ToCourthouse()
    {
        SceneManager.LoadScene("Courthouse");
    }

    public void ToTrialRoom()
    {
        SceneManager.LoadScene("TrialRoom");
    }

}