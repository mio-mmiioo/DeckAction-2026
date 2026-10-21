using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour
{ 

    [SerializeField] private CardDataBase cardDataBase;// 参照するカードのデータベース

 

   public void SetCardImage(int ID)
    {
        GetComponent<Image>().sprite = cardDataBase.CardData[ID].image;
    }

}
