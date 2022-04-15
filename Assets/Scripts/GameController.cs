using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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


    //ShopItemView
    public FloatView waterView;
    public FloatView canView;
    public FloatView bandageView;
    public FloatView gunView;
    public FloatView shieldView;

    //ShopUpgradeMagasinsView
    public FloatView tempManagerView;
    public FloatView frequenceView;
    public FloatView venteX2View;
    public FloatView baratinageView;
    public FloatView upgradeCharacterView;

    //LevelView
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

    //Variables pour l'avancement des barres de chargement
    [SerializeField] TimeBarShop _timeBarShopWater;
    [SerializeField] TimeBarShop _timeBarShopCan;
    [SerializeField] TimeBarShop _timeBarShopBandage;
    [SerializeField] TimeBarShop _timeBarShopGun;
    [SerializeField] TimeBarShop _timeBarShopShield;

    //Spawn Characters
    private int i;
    public GameObject CharacterPrefab;
    public GameObject CharacterPrefab2;
    public GameObject CharacterPrefab3;
    public GameObject MilitairePrefab;

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

        _waterTriggerShop._timeBarShop.AddListener(OnTriggerWaterShop);
        _canTriggerShop._timeBarShop.AddListener(OnTriggerCanShop);
        _bandageTriggerShop._timeBarShop.AddListener(OnTriggerBandageShop);
        _gunTriggerShop._timeBarShop.AddListener(OnTriggerGunShop);
        _shieldTriggerShop._timeBarShop.AddListener(OnTriggerShieldShop);

        // LOAD GAME if needed
        if (SceneManager.LOAD_GAME)
        {
            string savedMoney = PlayerPrefs.GetString("money");
            //string savedHitPowerWater = PlayerPrefs.GetString("hitpowerwater");
            //string savedShopPrizeWater = PlayerPrefs.GetString("shopprizewater");
            //string savedWaterPrice = PlayerPrefs.GetString("waterprice");
            //int savedWaterAmount = PlayerPrefs.GetInt("amountwater");

            float savedMoneyFloat = float.Parse(savedMoney);
            //float savedHitFloat = float.Parse(savedHitPowerWater);
            //float savedShopFloat = float.Parse(savedShopPrizeWater);
            //float savedWaterFloat = float.Parse(savedWaterPrice);
            //int savedWaterFloat = int.Parse("savedWaterAmount);

            _gameModel.GetMoney().Set(savedMoneyFloat);
            //_gameModel.GetWater().Set(savedHitFloat);
            //_gameModel.GetMoney().Set(savedShopFloat);
            //_gameModel.GetMoney().Set(savedWaterFloat);
            //_gameModel.GetAmountWater().Set(savedWaterFloat);


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
        int i = Random.Range(1, 100);
        GameObject obj;
        if (i < 25)
        {
            obj = GameObject.Instantiate(CharacterPrefab);
        }
        else if (i < 50)
        {
            obj = GameObject.Instantiate(CharacterPrefab2);
        }
        else if (i >90)
        {
            obj = GameObject.Instantiate(MilitairePrefab);
        }
        else
        {
            obj = GameObject.Instantiate(CharacterPrefab);
        }
        GameObject client = obj;
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
        if (hasClient(_waterTriggerShop))
        {
            _timeBarShopWater.progressBarShop.value += 0.06f;
        }
    }
    public void ClicOnCanShop()
    {
        if (hasClient(_canTriggerShop))
        {
            _timeBarShopCan.progressBarShop.value += 0.04f;
        }
    }
    public void ClicOnBandageShop()
    {
        if (hasClient(_bandageTriggerShop))
        {
            _timeBarShopBandage.progressBarShop.value += 0.03f;
        }
    }
    public void ClicOnGunShop()
    {
        if (hasClient(_gunTriggerShop))
        {
            _timeBarShopGun.progressBarShop.value += 0.02f;
        }
    }
    public void ClicOnShieldShop()
    {
        if (hasClient(_shieldTriggerShop))
        {
            _timeBarShopShield.progressBarShop.value += 0.01f;
        }
    }

    private void UpgradeTempManager()
    {
        _gameModel.DelayManager();
        _timeBarShopWater.fillSpeed += 0.05f;
        _timeBarShopCan.fillSpeed += 0.05f;
        _timeBarShopBandage.fillSpeed += 0.05f;
        _timeBarShopGun.fillSpeed += 0.05f;
        _timeBarShopShield.fillSpeed += 0.05f;
    }


    private void UpgradeFrequence()
    {
        _gameModel.FrequenceClients();
        spawnTime -= 0.2f;
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

    private bool hasClient(TriggerShop triggerShop)
    {
        if (triggerShop.currentClient != null)
        {
            return true;
        }
        else
        {
            return false;
        }
        return false;
    }

}
