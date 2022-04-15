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
    //public TextMeshProUGUI hitPowerWater;
    //public TextMeshProUGUI shopPrizeWater;
    //private TextMeshProUGUI waterPrice;
    //public int AmountWater;



    public void clickSaveButton()
    {

        PlayerPrefs.SetString("money", currentMoney.text);
        //PlayerPrefs.SetString("hitpowerwater", hitPowerWater.text);
        //PlayerPrefs.SetString("shopprizewater", shopPrizeWater.text);
        //PlayerPrefs.SetString("waterprice", waterPrice.text);
        //PlayerPrefs.SetInt("amountwater", AmountWater);


        PlayerPrefs.Save();
        //Debug.Log("Tu as " + PlayerPrefs.GetString("money"));
    }

}
