using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 [System.Serializable]
public class Data 
{
    
    public FloatObservable currentMoney;


    public Data (GameModel gamemodel)
    {
        currentMoney = gamemodel.currentMoney;
    }
}
