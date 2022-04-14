using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeBarShop : MonoBehaviour
{
    public Slider progressBarShop;

    private float targetProgress;
    public float fillSpeed = 0.5f;

    public bool isClientInShop;

    UnityEvent onTimerFinished;

    private void Awake()
    {
        onTimerFinished = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(1f);
    }


   
    // Update is called once per frame
    void Update()
    {
        Progression();
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = progressBarShop.value + newProgress;
    }

    public void Progression()
    {
        if (isClientInShop)
        {
            if (progressBarShop.value < targetProgress)
            {
                progressBarShop.value += fillSpeed * Time.deltaTime;
            }
            else
            {
                isClientInShop = false;
                progressBarShop.value = 0;
                onTimerFinished.Invoke();

            }
        }

    }

    public void AddListener(UnityAction listener)
    {
        onTimerFinished.AddListener(listener);
    }
}
