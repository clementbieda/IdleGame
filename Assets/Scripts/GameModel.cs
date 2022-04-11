using System;
using System.Collections;
using System.Collections.Generic;

public class GameModel
{

    private Random rnd;

    public float thresholdWinX2;

    public float timeManager = 3f;

    const float PERCENT_UPGRADE_WATER = 0.15f;
    const float PERCENT_UPGRADE_CAN = 0.24f;
    const float PERCENT_UPGRADE_BANDAGE = 0.3f;
    const float PERCENT_UPGRADE_GUN = 0.41f;
    const float PERCENT_UPGRADE_SHIELD = 0.5f;

    const float PERCENT_UPGRADE_TEMP_MANAGER = 0.20f;
    const float PERCENT_UPGRADE_VENTEX2 = 0.34f;
    const float PERCENT_UPGRADE_FREQUENCE = 0.4f;
    const float PERCENT_UPGRADE_BARATINAGE = 0.51f;
    const float PERCENT_UPGRADE_CHARACTERS = 0.6f;



    public FloatObservable currentMoney;

    //Le nombre d'argent que l'on gagne par clic
    public float hitPowerWater;
    public float hitPowerCan;
    public float hitPowerBandage;
    public float hitPowerGun;
    public float hitPowerShield;


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
    public FloatObservable AmountWater;
    public FloatObservable AmountCan;
    public FloatObservable AmountBandage;
    public FloatObservable AmountGun;
    public FloatObservable AmountShield;

    public int AmountTempManager;
    public int AmountVenteX2;
    public int AmountFrequence;
    public int AmountBaratinage;
    public int AmountUpgradeCharacter;

    //Upgrades magasins
    private FloatObservable tempManagerPrice;
    private FloatObservable venteX2Price;
    private FloatObservable frequencePrice;
    private FloatObservable baratinagePrice;
    private FloatObservable upgradeCharactersPrice;

    public int shopPrizeTempManager;
    public int shopPrizeVenteX2;
    public int shopPrizeFrequence;
    public int shopPrizeBaratinage;
    public int shopPrizeUpgradeCharacter;



    //Getters sur les prix des améliorations des magasins

    internal FloatObservable GetTempManager()
    {
        return tempManagerPrice;
    }

    internal FloatObservable GetVenteX2()
    {
        return venteX2Price;
    }

    internal FloatObservable GetFrequence()
    {
        return frequencePrice;
    }

    internal FloatObservable GetBaratinage()
    {
        return baratinagePrice;
    }

    internal FloatObservable GetUpgradeCharacter()
    {
        return upgradeCharactersPrice;
    }


    //Getters sur les prix des items

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


    //Getters sur les conteurs de level

    internal FloatObservable GetAmountWater()
    {
        return AmountWater;
    }

    internal FloatObservable GetAmountCan()
    {
        return AmountCan;
    }

    internal FloatObservable GetAmountBandages()
    {
        return AmountBandage;
    }

    internal FloatObservable GetAmountGun()
    {
        return AmountGun;
    }

    internal FloatObservable GetAmountShield()
    {
        return AmountShield;
    }





    public GameModel()
    {
        rnd = new System.Random();

        currentMoney = new FloatObservable(0);


        hitPowerWater = 1;
        hitPowerCan = 5;
        hitPowerBandage = 20;
        hitPowerGun = 100;
        hitPowerShield = 500;


        moneyIncreasePerSecond = 1;
        x = 0f;
        thresholdWinX2 = 0.2f;


        waterPrice = new FloatObservable(25);
        canPrice = new FloatObservable(50);
        bandagePrice = new FloatObservable(250);
        gunPrice = new FloatObservable(3000);
        shieldPrice = new FloatObservable(12500);

        tempManagerPrice = new FloatObservable(1000);
        frequencePrice = new FloatObservable(5000);
        venteX2Price = new FloatObservable(15500);
        baratinagePrice = new FloatObservable(22000);
        upgradeCharactersPrice = new FloatObservable(150000);
    }

    internal FloatObservable GetMoney()
    {
        return currentMoney;
    }

    //Améliorations sur les items

    public void UpgradeWater()
    {
        if (currentMoney.GetValue() >= waterPrice.GetValue())
        {
            currentMoney.Set(currentMoney.GetValue() - waterPrice.GetValue());
            waterPrice.Add(PERCENT_UPGRADE_WATER * waterPrice.GetValue());
            hitPowerWater += 1;
            AmountWater.Set(AmountWater.GetValue() + 1);
        }
    }

    internal void UpgradeCan()
    {
        if (currentMoney.GetValue() >= canPrice.GetValue())
        {
            
            currentMoney.Set(currentMoney.GetValue() - canPrice.GetValue());
            canPrice.Add(PERCENT_UPGRADE_CAN * canPrice.GetValue());
            hitPowerCan += 5;
            AmountCan.Set(AmountCan.GetValue() + 1);
        }
    }

    internal void UpgradeBandage()
    {
        if (currentMoney.GetValue() >= bandagePrice.GetValue())
        {
            
            currentMoney.Set(currentMoney.GetValue() - bandagePrice.GetValue());
            bandagePrice.Add(PERCENT_UPGRADE_BANDAGE * bandagePrice.GetValue());
            hitPowerBandage += 20;
            AmountBandage.Set(AmountBandage.GetValue() + 1);
        }
    }

    internal void UpgradeGun()
    {
        if (currentMoney.GetValue() >= gunPrice.GetValue())
        {
            
            currentMoney.Set(currentMoney.GetValue() - gunPrice.GetValue());
            gunPrice.Add(PERCENT_UPGRADE_GUN * gunPrice.GetValue());
            hitPowerGun += 100;
            AmountGun.Set(AmountGun.GetValue() + 1);
        }
    }

    internal void UpgradeShield()
    {
        if (currentMoney.GetValue() >= shieldPrice.GetValue())
        {
            
            currentMoney.Set(currentMoney.GetValue() - shieldPrice.GetValue());
            shieldPrice.Add(PERCENT_UPGRADE_SHIELD * shieldPrice.GetValue());
            hitPowerShield += 500;
            AmountShield.Set(AmountShield.GetValue() + 1);
        }
    }

    // Click sur le bouton

    public void HitWater()
    {
        currentMoney.Add(hitPowerWater);
    }
    public void HitCan()
    {
        currentMoney.Add(hitPowerCan);
    }
    public void HitBandage()
    {
        currentMoney.Add(hitPowerBandage);
    }
    public void HitGun()
    {
        currentMoney.Add(hitPowerGun);
    }
    public void HitShield()
    {
        currentMoney.Add(hitPowerShield);
    }

    //Améliorations sur les magasins

    public void DelayManager()
    {
        if (currentMoney.GetValue() >= tempManagerPrice.GetValue())
        {
            AmountTempManager++;
            currentMoney.Set(currentMoney.GetValue() - tempManagerPrice.GetValue());
            tempManagerPrice.Add(PERCENT_UPGRADE_TEMP_MANAGER * tempManagerPrice.GetValue());
            
        }
    }

    public void FrequenceClients()
    {
        if (currentMoney.GetValue() >= frequencePrice.GetValue())
        {
            AmountFrequence++;
            currentMoney.Set(currentMoney.GetValue() - frequencePrice.GetValue());
            frequencePrice.Add(PERCENT_UPGRADE_FREQUENCE * frequencePrice.GetValue());
            
        }
    }

    public void Baratinage()
    {
        if (currentMoney.GetValue() >= baratinagePrice.GetValue())
        {
            AmountBaratinage++;
            currentMoney.Set(currentMoney.GetValue() - baratinagePrice.GetValue());
            baratinagePrice.Add(PERCENT_UPGRADE_BARATINAGE * baratinagePrice.GetValue());
            
        }
    }


    public bool CheckX2Win()
    { 
        return rnd.Next() < thresholdWinX2;
    }

    public void UpgradeCharacters()
    {
        if (currentMoney.GetValue() >= upgradeCharactersPrice.GetValue())
        {
            AmountUpgradeCharacter++;
            currentMoney.Set(currentMoney.GetValue() - upgradeCharactersPrice.GetValue());
            upgradeCharactersPrice.Add(PERCENT_UPGRADE_CHARACTERS * upgradeCharactersPrice.GetValue());
            
        }
    }

    public void VenteX2()
    {
        if (currentMoney.GetValue() >= venteX2Price.GetValue())
        {
            AmountVenteX2++;
            currentMoney.Set(currentMoney.GetValue() - venteX2Price.GetValue());
            venteX2Price.Add(PERCENT_UPGRADE_VENTEX2 * venteX2Price.GetValue());
            
        }
    }
}
