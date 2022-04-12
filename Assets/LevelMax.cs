using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMax : MonoBehaviour
{
    public Button yourbutton;

    public int level = 1;

    public void DisableButton ()
    {
        level++;
        
        if (level == 5)
        {
            yourbutton.interactable = false;
        }
        
    }
}
