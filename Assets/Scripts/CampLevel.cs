using UnityEngine;
using UnityEngine.UI;

public class CampLevel : MonoBehaviour
{
    public Button button1;
    public Sprite sprite1, sprite2, sprite3, sprite4, sprite5;

    void Start()
    {

        ChangeSprite(sprite1);

    }

    public void ChangeSprite(Sprite sprite) 
    {
        button1.GetComponent<Image>().sprite = sprite;

        ChangeSprite(sprite);
    }
}