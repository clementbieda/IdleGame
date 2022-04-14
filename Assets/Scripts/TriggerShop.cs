using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerShop : MonoBehaviour
{
    UnityEvent _onTriggerShop;
    UnityEvent _onGetMoney;
    [SerializeField] TimeBarShop _timeBarShop;
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
        collision.GetComponent<CharactersMovement>().Stop();
        _timeBarShop.AddListener(collision.GetComponent<CharactersMovement>().Play);
        _timeBarShop.isClientInShop = true;


    }

    public void AddListener(UnityAction listener)
    {
        if (_onTriggerShop == null)
        {
            _onTriggerShop = new UnityEvent();
        }
        _onTriggerShop.AddListener(listener);
    }

    public void AddListenerMoney(UnityAction listener)
    {
        if (_onGetMoney == null)
        {
            _onGetMoney = new UnityEvent();
        }
        _onGetMoney.AddListener(listener);
    }
}
