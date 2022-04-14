using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SaveLoad : MonoBehaviour
{

    public TextMeshProUGUI currentMoney;


    public void clickSaveButton()
    {

        PlayerPrefs.SetString("money", currentMoney.text);
        PlayerPrefs.Save();
        Debug.Log("Tu as " + PlayerPrefs.GetString("money"));
    }

    
}
