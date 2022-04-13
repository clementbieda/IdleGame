using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 [System.Serializable]
public class PlayerData 
{
    
    public FloatObservable currentMoney;


    public PlayerData (Player player)
    {
        currentMoney = player.currentMoney;
    }
}
