using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public AudioSource sound;
    public GameObject character;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            character.GetComponent<AudioSource>().Play();
        }
    }
}
