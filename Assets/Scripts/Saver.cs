/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{

    public void Start()
    {
        Load();
    }

    public void Load()
    {
        coins = double.Parse(PlayerPrefs.GetString("coins", "0"));
        hitPower = double.Parse(PlayerPrefs.GetString("hitPower", "1"));
        currentMoney = double.Parse(PlayerPrefs.GetString("currentMoney", "0"));
        waterPrice = double.Parse(PlayerPrefs.GetString("waterPrice", "0"));
        AmountWater = double.Parse(PlayerPrefs.GetString("AmountWater", "0"));
        shopPrizeWater = double.Parse(PlayerPrefs.GetString("shopPrizeWater", "0"));
        moneyIncreasePerSecond = double.Parse(PlayerPrefs.GetString("moneyIncreasePerSecond", "0"));


    }

    public void Save()
    {
        PlayerPrefs.SetString("coins", coins.ToString());
        PlayerPrefs.SetString("hitPower", hitPower.ToString());
        PlayerPrefs.SetString("currentMoney", currentMoney.ToString());
        PlayerPrefs.SetString("waterPrice", waterPrice.ToString());
        PlayerPrefs.SetString("AmountWater", AmountWater.ToString());
        PlayerPrefs.SetString("shopPrizeWater", shopPrizeWater.ToString());
        PlayerPrefs.SetString("moneyIncreasePerSecond", moneyIncreasePerSecond.ToString());
        
    }
}
*/
