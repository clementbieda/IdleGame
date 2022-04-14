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

    //waypoints
    [SerializeField] List<Transform> _waypointsWater;
    [SerializeField] List<Transform> _waypointsCan;
    [SerializeField] List<Transform> _waypointsBandage;
    [SerializeField] List<Transform> _waypointsGun;
    [SerializeField] List<Transform> _waypointsShield;

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
    [SerializeField] private float spawnTime;
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
        _BandageShopButton.onClick.AddListener(ClicOnBandageShop);
        _GunShopButton.onClick.AddListener(ClicOnGunShop);
        _ShieldShopButton.onClick.AddListener(ClicOnShieldShop);

        _waterTriggerShop.AddListener(OnTriggerWaterShop);
        _canTriggerShop.AddListener(OnTriggerCanShop);
        _bandageTriggerShop.AddListener(OnTriggerBandageShop);
        _gunTriggerShop.AddListener(OnTriggerGunShop);
        _shieldTriggerShop.AddListener(OnTriggerShieldShop);

        // LOAD GAME if needed
        if (SceneManager.LOAD_GAME)
        {
            string savedMoney = PlayerPrefs.GetString("money");

            float savedMoneyFloat = float.Parse(savedMoney);

            _gameModel.GetMoney().Set(savedMoneyFloat);

        }

        //On appelle la fonction qui génère les vagues dans le start
        StartCoroutine(WaveGenerate());

    }
    
    private void OnTriggerShieldShop()
    {
        _gameModel.HitShield();
    }

    private void OnTriggerGunShop()
    {
        _gameModel.HitGun();
    }

    private void OnTriggerBandageShop()
    {
        _gameModel.HitBandage();
    }

    private void OnTriggerCanShop()
    {
        _gameModel.HitCan();
    }
    
    private void OnTriggerWaterShop()
    {
        _gameModel.HitWater();
    }
    
    private void spawnClient()
    {
        GameObject client = GameObject.Instantiate(CharacterPrefab);
        client.GetComponent<CharactersMovement>().Init(_waypointsWater, _waypointsCan, _waypointsBandage, _waypointsGun, _waypointsShield);
        //Instantiate(CharacterPrefab, new Vector3(-15, -7, 0), Quaternion.identity);
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
