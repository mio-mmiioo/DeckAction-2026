using System.Collections.Generic;
using UnityEngine;

public class UsingCardView : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;// 
    [SerializeField] private CardDataBase cardDataBase;// 


    [Tooltip("カードとカードの間の距離")]
    [SerializeField] private float spacing = 60;

    [Tooltip("基準とする左端")]
    [SerializeField] private float cardUpperLeft = 60;

    [Tooltip("カード全体の高さ")]
    [SerializeField] private float cardY = 20;

    void Update()
    {
        
    }

    public void CardViewSort(List<BaseCard> cards)
    {
        int count = cards.Count;

        if (count == 0) return;

        float totalWidth = (count - 1) * spacing;

        for (int i = 0; i < count; i++)
        {
            BaseCard card = cards[i];

            if (card == null) continue;

            Transform pos = card.GetComponent<Transform>();

            pos.position = new Vector2(
                cardUpperLeft + i * spacing,
                cardY
            );

            pos.SetAsLastSibling();
            pos.localRotation = Quaternion.identity;
        }
    }


}
