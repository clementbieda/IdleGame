using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarShop : MonoBehaviour
{
    public Slider timeBarShop;

    private float maxTime = 100f;
    private float currentTime;

    private WaitForSeconds upTick = new WaitForSeconds(0.1f);

    public static TimeBarShop instance;

    private Coroutine regen;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        timeBarShop.maxValue = maxTime;
        timeBarShop.value = maxTime;
    }

    public void UseTimeBar(float amount)
    {
        if (currentTime - amount >= 0)
        {
            currentTime -= amount;
            timeBarShop.value = currentTime;

            regen = StartCoroutine(UpTimeBar());
        }
        else
        {
            Debug.Log("La vente n'est pas prête");
        }
    }

    private IEnumerator UpTimeBar()
    {
        yield return new WaitForSeconds(2);

        while(currentTime < maxTime)
        {
            currentTime += maxTime / 100;
            timeBarShop.value = currentTime;
            yield return upTick;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
