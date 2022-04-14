using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class GameScene : MonoBehaviour
{

    public TextMeshProUGUI Money;




    // Start is called before the first frame update
    void Start()
    {
        Money.text = PlayerPrefs.GetString("money");
    }

    
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("name");
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene 1");
    }
}