using System;
using System.Collections;
using System.Collections.Generic;

public class GameModel
{

    private Random rnd;

    public float thresholdWinX2;

    //Magasins
    public FloatObservable currentMoney;
    public float hitPower;
    public float moneyIncreasePerSecond;
    public float x;


    //Shop
    public int shopPrize;

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
        if (currentMoney.GetValue() >= shopPrize)
        {
            AmountWater++;
            waterPrice.Add(0.15f * waterPrice.GetValue());
        }
    }

    internal void UpgradeCan()
    {
        if (currentMoney.GetValue() >= shopPrize)
        {
            AmountCan++;
            canPrice.Add(0.26f * canPrice.GetValue());
        }
    }

    internal void UpgradeBandage()
    {
        if (currentMoney.GetValue() >= shopPrize)
        {
            AmountBandage++;
            bandagePrice.Add(0.35f * bandagePrice.GetValue());
        }
    }

    internal void UpgradeGun()
    {
        if (currentMoney.GetValue() >= shopPrize)
        {
            AmountGun++;
            gunPrice.Add(0.45f * gunPrice.GetValue());
        }
    }

    internal void UpgradeShield()
    {
        if (currentMoney.GetValue() >= shopPrize)
        {
            AmountShield++;
            shieldPrice.Add(0.6f * shieldPrice.GetValue());
        }
    }

    public void Hit()
    {
        currentMoney.Add(hitPower);
    }


    public void BuyManager()
    {
        if (currentMoney.GetValue() >= shopPrize)
        {
            currentMoney.Add(-shopPrize);
            profit1 += 1;
            x += 1;
            shopPrize += 25;
        }
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
