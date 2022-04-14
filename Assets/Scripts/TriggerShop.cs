using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerShop : MonoBehaviour
{
    UnityEvent _onTriggerShop;

    public CharactersMovement currentClient;
    public List<CharactersMovement> waitingClient;

    [SerializeField] public TimeBarShop _timeBarShop;
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
        if (_onTriggerShop != null)
        {
            _onTriggerShop.Invoke();

        }

        if (currentClient == null)
        {
            currentClient = collision.GetComponent<CharactersMovement>();
            StartTimeBar();
        }
        else
        {
            waitingClient.Add(collision.GetComponent<CharactersMovement>());
            collision.GetComponent<CharactersMovement>().Stop();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (waitingClient.Count > 0)
        {
            currentClient = waitingClient[0];
            waitingClient.Remove(currentClient);
            StartTimeBar();
        }
        else
        {
            currentClient = null;
        }
    }

    void StartTimeBar()
    {
        currentClient.Stop();
        _timeBarShop.AddListener(currentClient.Play);
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
}
