using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;
using System.Linq;

public class CampLevel : MonoBehaviour
{
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



}