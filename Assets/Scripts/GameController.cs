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

    [SerializeField] private Button _testMoneyAdd;

    //Magasins
    public FloatView moneyView;


    //Shop
    public FloatView waterView;
    public FloatView canView;
    public FloatView bandageView;
    public FloatView gunView;
    public FloatView shieldView;


    
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
        _gameModel.GetWater().Subscribe(waterView);
        _gameModel.GetCan().Subscribe(canView);
        _gameModel.GetBandages().Subscribe(bandageView);
        _gameModel.GetGun().Subscribe(gunView);
        _gameModel.GetShield().Subscribe(shieldView);

        _upgradeWaterButton.onClick.AddListener(UpgradeWater);
        _upgradeCanButton.onClick.AddListener(UpgradeCan);
        _upgradeBandageButton.onClick.AddListener(UpgradeBandage);
        _upgradeGunButton.onClick.AddListener(UpgradeGun);
        _upgradeShieldButton.onClick.AddListener(UpgradeShield);

        _testMoneyAdd.onClick.AddListener(TestAddMoney);

        //On appelle la fonction qui génère les vagues dans le start
        StartCoroutine(WaveGenerate());

    }

    IEnumerator WaveGenerate()
    {
        while (isInGame)
        {
            //On fait spawn un ennemi à chaque itération dans la boucle
            for (int i = 0; i < ennemyWave; i++)
            {
                Vector3 spawnPos = new Vector3(5,2,0);
                Instantiate(CharacterPrefab, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnTime);
            }

            //On laisse un temps entre chaque vague de spawn
            yield return new WaitForSeconds(waveTime);
        }
    }

    private void TestAddMoney()
    {
        _gameModel.Hit();
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

    public void ClicOnButton()
    {
        _gameModel.Hit();
    }

    
}
