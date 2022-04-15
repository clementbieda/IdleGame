using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManager : MonoBehaviour
{
    public static bool LOAD_GAME;



    // Start is called before the first frame update
    public void NewGame ()
    {
        LOAD_GAME = false;
        PlayerPrefs.DeleteKey("money");

        PlayerPrefs.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene 1");
        Debug.Log("clique play détecté");
    }

    // Update is called once per frame
    public void Options()
    {
        Debug.Log("clique options détecté");
    }

    public void LoadGame()
    {
        LOAD_GAME = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene 1");
        Debug.Log("clique load détecté");
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log ("clique quit détecté");
    }

    public void Menu ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu_");
    }

    

}
