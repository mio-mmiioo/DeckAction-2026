using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardVisual : MonoBehaviour
{

    [Tooltip("参照するカードのデータベース")]
    [SerializeField] private CardDataBase cardDataBase;


   public void SetCardImage(int ID)
    {
        GetComponent<Image>().sprite = cardDataBase.CardData[ID].image;
    }
}
