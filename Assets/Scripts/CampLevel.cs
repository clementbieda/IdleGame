using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

public class CampLevel : MonoBehaviour
{
    public bool etat = true;
    public bool etat2 = true;
    public bool etat3 = true;
    public bool etat4 = true;
    public bool etat5 = true;

    //mettre  1 pour le premier et 0 pour les autres


    [SerializeField]
    private SpriteLibrary spriteLibrary = default;

    [SerializeField]
    private SpriteResolver targetResolver = default;

    [SerializeField]
    private string targetCategory = default;

    private int etape = 1;

    private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;


    // 

    internal void SelectRandom()
    {
    string[] labels =
      LibraryAsset.GetCategoryLabelNames(targetCategory).ToArray();
    int index = etape++; // faire condition pour pas dépasser 5, et faire de 1 en 1 en changeant le 
    string label = labels[index];

    

    targetResolver.SetCategoryAndLabel(targetCategory, label);


    }

    public void ButtonClick()
    {
        if (etat)
        {
            SelectRandom();
            etat = false;
        }
    }
    public void ButtonClick2()
    {
        if (etat2)
        {
            SelectRandom();
            etat2 = false;
        }
    }
    public void ButtonClick3()
    {
        if (etat3)
        {
            SelectRandom();
            etat3 = false;
        }
    }
    public void ButtonClick4()
    {
        if (etat4)
        {
            SelectRandom();
            etat4 = false;
        }
    }
    public void ButtonClick5()
    {
        if (etat5)
        {
            SelectRandom();
            etat5 = false;
        }
    }

    internal void Available()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}