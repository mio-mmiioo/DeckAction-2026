using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 手札の表示とソートするクラス
/// </summary>
public class PlayerHands : MonoBehaviour
{
    [SerializeField] private BaseCard baseCard;// BaseCardのプレハブ

    [SerializeField] private CardManager cardManager ;// 

    [SerializeField] private float spacing = 60;
    [SerializeField] private float cardUpperLeft = 60;
    


    public void CardViewSort(List<BaseCard> cards)
    {
        int count = cards.Count;

        if (count == 0) return;

        float totalWidth = (count - 1) * spacing;

        for (int i = 0; i < count; i++)
        {
            BaseCard card = cards[i];

            if (card == null) continue;

            RectTransform rect =card.GetComponent<RectTransform>();

            rect.anchoredPosition = new Vector2(
                cardUpperLeft + i * spacing,
                0f
            );

            rect.localRotation = Quaternion.identity;
        }
    }

}
