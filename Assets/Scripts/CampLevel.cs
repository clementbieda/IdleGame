using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampLevel : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] spriteArray;
    public int state;

    void Start()
    {
        spriteArray = Resources.LoadAll<Sprite>("BirdHeroSprite");

    }

    public void ChangeSprite() 
    { 
        spriteRenderer.sprite = spriteArray[0]; 
    }


}
