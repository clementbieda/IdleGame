using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private GameModel _gameModel;
    
    
    //Boutons d'améliorations pour les items
    [SerializeField] private Button _upgradeWaterButton;
    [SerializeField] private Button _upgradeCanButton;
    [SerializeField] private Button _upgradeBandageButton;
    [SerializeField] private Button _upgradeGunButton;
    [SerializeField] private Button _upgradeShieldButton;


    //Boutons d'amélioration pour les magasins
    [SerializeField] private Button _upgradeTempManagerButton;
    [SerializeField] private Button _upgradeFrequenceButton;
    [SerializeField] private Button _upgradeVenteX2Button;
    [SerializeField] private Button _upgradeBaratinageButton;
    [SerializeField] private Button _upgradeCharactersButton;

    //Boutons représentant les magasins
    [SerializeField] private Button _WaterShopButton;
    [SerializeField] private Button _CanShopButton;
    [SerializeField] private Button _BandageShopButton;
    [SerializeField] private Button _GunShopButton;
    [SerializeField] private Button _ShieldShopButton;

    //Money
    public FloatView moneyView;


    //Shop
    public FloatView waterView;
    public FloatView canView;
    public FloatView bandageView;
    public FloatView gunView;
    public FloatView shieldView;

    public FloatView tempManagerView;
    public FloatView frequenceView;
    public FloatView venteX2View;
    public FloatView baratinageView;
    public FloatView upgradeCharacterView;

    public FloatView waterAmountView;
    public FloatView canAmountView;
    public FloatView bandageAmountView;
    public FloatView gunAmountView;
    public FloatView shieldAmountView;

    //TriggerShopView
    public TriggerShop _waterTriggerShop;
    public TriggerShop _canTriggerShop;
    public TriggerShop _bandageTriggerShop;
    public TriggerShop _gunTriggerShop;
    public TriggerShop _shieldTriggerShop;

    //Temporalité des managers
    public float MaxTime = 3f;
    public float ActiveTime = 0f;
    public Image _tempManager;



    //Spawn Characters
    public GameObject CharacterPrefab;
    public int ennemyWave;
    public float spawnTime = 1.0f;
    public bool isInGame = true;

    public float waveTime;
    // Start is called before the first frame update


    // Start is called before the first frame update
    void Start()
    {
        _gameModel = new GameModel();
        _gameModel.GetMoney().Subscribe(moneyView);

        //Couple model vers vue pour les items
        _gameModel.GetWater().Subscribe(waterView);
        _gameModel.GetCan().Subscribe(canView);
        _gameModel.GetBandages().Subscribe(bandageView);
        _gameModel.GetGun().Subscribe(gunView);
        _gameModel.GetShield().Subscribe(shieldView);


        //
        _gameModel.GetAmountWater().Subscribe(waterAmountView);
        _gameModel.GetAmountCan().Subscribe(canAmountView);
        _gameModel.GetAmountBandages().Subscribe(bandageAmountView);
        _gameModel.GetAmountGun().Subscribe(gunAmountView);
        _gameModel.GetAmountShield().Subscribe(shieldAmountView);



        //Rattachement au clic
        _upgradeWaterButton.onClick.AddListener(UpgradeWater);
        _upgradeCanButton.onClick.AddListener(UpgradeCan);
        _upgradeBandageButton.onClick.AddListener(UpgradeBandage);
        _upgradeGunButton.onClick.AddListener(UpgradeGun);
        _upgradeShieldButton.onClick.AddListener(UpgradeShield);

        //Couple model vers vue pour les magasins
        _gameModel.GetTempManager().Subscribe(tempManagerView);
        _gameModel.GetFrequence().Subscribe(frequenceView);
        _gameModel.GetVenteX2().Subscribe(venteX2View);
        _gameModel.GetBaratinage().Subscribe(baratinageView);
        _gameModel.GetUpgradeCharacter().Subscribe(upgradeCharacterView);


        _upgradeTempManagerButton.onClick.AddListener(UpgradeTempManager);
        _upgradeFrequenceButton.onClick.AddListener(UpgradeFrequence);
        _upgradeVenteX2Button.onClick.AddListener(UpgradeVenteX2);
        _upgradeBaratinageButton.onClick.AddListener(UpgradeBaratinage);
        _upgradeCharactersButton.onClick.AddListener(UpgradeCharacter);


        _WaterShopButton.onClick.AddListener(ClicOnWaterShop);
        _CanShopButton.onClick.AddListener(ClicOnCanShop);
        //_BandageShopButton.onClick.AddListener(ClicOnBandageShop);
        //_GunShopButton.onClick.AddListener(ClicOnGunShop);
        //_ShieldShopButton.onClick.AddListener(ClicOnShieldShop);

        _waterTriggerShop.AddListener(OnTriggerWaterShop);
        _canTriggerShop.AddListener(OnTriggerCanShop);
        _bandageTriggerShop.AddListener(OnTriggerBandageShop);
        _gunTriggerShop.AddListener(OnTriggerGunShop);
        _shieldTriggerShop.AddListener(OnTriggerShieldShop);


        //On appelle la fonction qui génère les vagues dans le start
        StartCoroutine(WaveGenerate());

    }
    
    private void OnTriggerShieldShop()
    {
        Debug.Log("Un client est entré dans le Shield Shop");
    }

    private void OnTriggerGunShop()
    {
        Debug.Log("Un client est entré dans le Gun Shop");
    }

    private void OnTriggerBandageShop()
    {
        Debug.Log("Un client est entré dans le Bandage Shop");
    }

    private void OnTriggerCanShop()
    {
        Debug.Log("Un client est entré dans le Can Shop");
    }
    
    private void OnTriggerWaterShop()
    {
        Debug.Log("Un client est entré dans le Water Shop");
    }

    private void spawnClient()
    {
        GameObject a = Instantiate(CharacterPrefab) as GameObject;
    }

    IEnumerator WaveGenerate()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnClient();
        }
        
    }

    private void UpgradeWater()
    {
        _gameModel.UpgradeWater();
    }

    private void UpgradeCan()
    {
        _gameModel.UpgradeCan();
    }

    private void UpgradeBandage()
    {
        _gameModel.UpgradeBandage();
    }

    private void UpgradeGun()
    {
        _gameModel.UpgradeGun();
    }

    private void UpgradeShield()
    {
        _gameModel.UpgradeShield();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveTime += Time.deltaTime;
        var percent = ActiveTime / MaxTime;
        //_tempManager.fillAmount = Mathf.Lerp(0, 1, percent);
    }

    public void ClicOnWaterShop()
    {
        _gameModel.HitWater();
    }
    public void ClicOnCanShop()
    {
        _gameModel.HitCan();
    }
    public void ClicOnBandageShop()
    {
        _gameModel.HitBandage();
    }
    public void ClicOnGunShop()
    {
        _gameModel.HitGun();
    }
    public void ClicOnShieldShop()
    {
        _gameModel.HitShield();
    }

    private void UpgradeTempManager()
    {
        _gameModel.DelayManager();
    }


    private void UpgradeFrequence()
    {
        _gameModel.FrequenceClients();
    }


    private void UpgradeVenteX2()
    {
        _gameModel.VenteX2();
    }


    private void UpgradeBaratinage()
    {
        _gameModel.Baratinage();
    }


    private void UpgradeCharacter()
    {
        _gameModel.UpgradeCharacters();
    }


}
