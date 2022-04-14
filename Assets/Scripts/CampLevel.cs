using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;
using System.Linq;

public class CampLevel : MonoBehaviour
{

    public Button yourbutton;

    public int level; //mettre  1 pour le premier et 0 pour les autres


    [SerializeField]
    private SpriteLibrary spriteLibrary = default;

    [SerializeField]
    private SpriteResolver targetResolver = default;

    [SerializeField]
    private string targetCategory = default;

    private int etape = 1;

    private SpriteLibraryAsset LibraryAsset => spriteLibrary.spriteLibraryAsset;


    // 

    public void SelectRandom ()
    {
    string[] labels =
      LibraryAsset.GetCategoryLabelNames(targetCategory).ToArray();
    int index = etape++; // faire condition pour pas dépasser 5, et faire de 1 en 1 en changeant le 
    string label = labels[index];
    

    targetResolver.SetCategoryAndLabel(targetCategory, label);


    }

    public void DisableButton()
    {
        level++;

        if (level == 5)
        {
            yourbutton.interactable = false;
        }

    }



}