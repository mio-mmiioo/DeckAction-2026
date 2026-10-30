using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

/// <summary>
/// 手札の表示とソートするクラス
/// </summary>
public class HandsSort : MonoBehaviour
{
    [Tooltip("BaseCardのプレハブ")]
    [SerializeField] private BaseCard baseCard;

    [Tooltip("カードマネージャー")]
    [SerializeField] private CardManager cardManager ;

    [Tooltip("カードとカードの間の距離")]
    [SerializeField] private float spacing = 60;

    [Tooltip("基準とする左端")]
    [SerializeField] private float cardUpperLeft = 350;
    
    [Tooltip("カード全体の高さ")]
    [SerializeField] private float cardY = 20;

    [Tooltip("中央のカードの位置")]
    [SerializeField] private float cardBaseX = 30;

    Vector2 cardBasePos;

    private void Start()
    {
        cardBasePos = new Vector2(cardBaseX, cardY);
    }

    /// <summary>
    /// 基本的なカードのソート
    /// </summary>
    /// <param name="cards"></param>
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

            pos.position= new Vector2(
                cardUpperLeft + i * spacing,
                cardY
            );

            pos.SetAsLastSibling();
            pos.localRotation = Quaternion.identity;
        }
    }


    /// <summary>
    /// カードの中央でソートの計算
    /// </summary>
    /// <param name="cards"></param>
    public void CardViewSortMedian(List<BaseCard> cards)
    {

        int count = cards.Count;// カードの枚数
        if (count == 0) return;
        int handCenter=0;// 中央のカード
        int handSecondCenter = 0;// 偶数の場合の二枚目のカード
        if (count % 2 != 0)
        {
            handCenter= count-1 / 2;
        }
        else
        {
            handCenter= count+1 / 2;
            handSecondCenter = handCenter+1;
        }


        float totalWidth = (count - 1) * spacing;


        Debug.Log($"ソート対象のカード数: {cards.Count}");

        BaseCard card = cards[handCenter];
        Transform cardPos = card.GetComponent<Transform>();
        card.transform.SetSiblingIndex(handCenter);
        cardPos.position = cardBasePos;

        if(handCenter!=0)
        {

        }


        for (int i = 0; i < handCenter; i++)
        {
            card = cards[i];
            if (card == null) continue;

            Transform pos =card.GetComponent<Transform>();

            pos.position = new Vector2(
                cardBaseX - (handCenter-i) * spacing,
                cardY
            );

            pos.localRotation = Quaternion.identity;

            card.transform.SetSiblingIndex(i);
        }

        for(int i=handCenter+1;i<cards.Count;i++)
        {
            card = cards[i];
            if (card == null) continue;
            if (i == handSecondCenter) continue;

            Transform rect = card.GetComponent<Transform>();

            rect.position = new Vector2(
                cardBaseX + (i-handCenter) * spacing,
                cardY
            );

            rect.localRotation = Quaternion.identity;
            card.transform.SetSiblingIndex(i);
        }

        
    }

 
}
