using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardVisual : MonoBehaviour
{ 

    [SerializeField] private CardDataBase cardDataBase;// 参照するカードのデータベース
    [SerializeField] private Vector2 ankerPosition;//基準となるポジション

 

   public void SetCardImage(int ID)
    {
        GetComponent<Image>().sprite = cardDataBase.CardData[ID].image;
    }
}
