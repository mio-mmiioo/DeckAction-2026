using UnityEngine;

public class UsingCardView : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;// 
    [SerializeField] private CardDataBase cardDataBase;// 

    void Update()
    {
        if(cardManager.GetUseCard()<=cardDataBase.CardData.Count)
        {

        }
    }
}
