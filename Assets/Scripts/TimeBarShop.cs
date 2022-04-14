using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarShop : MonoBehaviour
{
    public Slider progressBarShop;

    private float targetProgress = 0;
    public float fillSpeed = 0.5f;



    private void Awake()
    {
        progressBarShop = gameObject.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(1f);
    }


   
    // Update is called once per frame
    void Update()
    {
        if (progressBarShop.value < targetProgress)
        {
            progressBarShop.value += fillSpeed * Time.deltaTime;
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = progressBarShop.value + newProgress;
    }
}
