using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampLevel : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite[] spriteArray;

    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


}
