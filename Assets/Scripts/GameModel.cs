using System;
using System.Collections;
using System.Collections.Generic;

public class GameModel
{

    private Random rnd;

    public float thresholdWinX2;

    const float PERCENT_UPGRADE_WATER = 0.15f;
    const float PERCENT_UPGRADE_CAN = 0.24f;
    const float PERCENT_UPGRADE_BANDAGE = 0.3f;
    const float PERCENT_UPGRADE_GUN = 0.41f;
    const float PERCENT_UPGRADE_SHIELD = 0.5f;

    //Magasins
    public FloatObservable currentMoney;
    public float hitPower;
    public float moneyIncreasePerSecond;
    public float x;


    //Shop
    public int shopPrizeWater;
    public int shopPrizeCan;
    public int shopPrizeBandage;
    public int shopPrizeGun;
    public int shopPrizeShield;

    private FloatObservable waterPrice;
    private FloatObservable canPrice;
    private FloatObservable bandagePrice;
    private FloatObservable gunPrice;
    private FloatObservable shieldPrice;


    //Amount
    public int AmountWater;
    public int AmountCan;
    public int AmountBandage;
    public int AmountGun;
    public int AmountShield;
    public int profit1;

    internal FloatObservable GetWater()
    {
        return waterPrice;
    }

    internal FloatObservable GetCan()
    {
        return canPrice;
    }

    internal FloatObservable GetBandages()
    {
        return bandagePrice;
    }

    internal FloatObservable GetGun()
    {
        return gunPrice;
    }

    internal FloatObservable GetShield()
    {
        return shieldPrice;
    }

    public GameModel()
    {
        rnd = new System.Random();

        currentMoney = new FloatObservable(0);
        hitPower = 1;
        moneyIncreasePerSecond = 1;
        x = 0f;
        thresholdWinX2 = 0.2f;
        waterPrice = new FloatObservable(25);
        canPrice = new FloatObservable(50);
        bandagePrice = new FloatObservable(250);
        gunPrice = new FloatObservable(3000);
        shieldPrice = new FloatObservable(12500);
    }

    internal FloatObservable GetMoney()
    {
        return currentMoney;
    }

    internal void UpgradeWater()
    {
        if (currentMoney.GetValue() >= shopPrizeWater)
        {
            AmountWater++;
            waterPrice.Add(PERCENT_UPGRADE_WATER * waterPrice.GetValue());
        }
    }

    internal void UpgradeCan()
    {
        if (currentMoney.GetValue() >= shopPrizeCan)
        {
            AmountCan++;
            canPrice.Add(PERCENT_UPGRADE_CAN * canPrice.GetValue());
        }
    }

    internal void UpgradeBandage()
    {
        if (currentMoney.GetValue() >= shopPrizeBandage)
        {
            AmountBandage++;
            bandagePrice.Add(PERCENT_UPGRADE_BANDAGE * bandagePrice.GetValue());
        }
    }

    internal void UpgradeGun()
    {
        if (currentMoney.GetValue() >= shopPrizeGun)
        {
            AmountGun++;
            gunPrice.Add(PERCENT_UPGRADE_GUN * gunPrice.GetValue());
        }
    }

    internal void UpgradeShield()
    {
        if (currentMoney.GetValue() >= shopPrizeShield)
        {
            AmountShield++;
            shieldPrice.Add(PERCENT_UPGRADE_SHIELD * shieldPrice.GetValue());
        }
    }

    public void Hit()
    {
        currentMoney.Add(hitPower);
    }

    public void DelayManager()
    {
        
    }

    public void VitesseClients()
    {

    }

    public void FrequenceClients()
    {

    }


    public bool CheckX2Win()
    {
        return rnd.Next() < thresholdWinX2;
    }
}
