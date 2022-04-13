using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMax : MonoBehaviour
{
    public Button yourbutton;

    public int level; //mettre  1 pour le premier et 0 pour les autres

    public void DisableButton ()
    {
        level++;
        
        if (level == 5)
        {
            yourbutton.interactable = false;
        }
        
    }
}
