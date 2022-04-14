using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveLoad : MonoBehaviour
{

    public TextMeshProUGUI currentMoney;


    public void clickSaveButton()
    {
        //PlayerPrefs.SetString("money", currentMoney.text);
        Debug.Log("Tu as " + PlayerPrefs.GetString("money"));
    }

    
}
