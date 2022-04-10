using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Debug.Log("clique play détecté");
    }

    // Update is called once per frame
    public void Options()
    {
        Debug.Log("clique options détecté");
    }

    public void Charger()
    {
        Debug.Log("clique load détecté");
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log ("clique quit détecté");
    }

}
