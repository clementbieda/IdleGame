using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerShop : MonoBehaviour
{
    UnityEvent _onTriggerShop;
    // Start is called before the first frame update
    void Start()
    {
        //_onTriggerShop = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        _onTriggerShop.Invoke();
    }

    public void AddListener(UnityAction listener)
    {
        if (_onTriggerShop == null)
        {
            _onTriggerShop = new UnityEvent();
        }
        _onTriggerShop.AddListener(listener);
    }
}
