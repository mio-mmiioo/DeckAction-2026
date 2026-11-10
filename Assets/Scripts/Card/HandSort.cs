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
    [SerializeField] private float spacing =10.0f;

    [Tooltip("基準とする左端")]
    [SerializeField] private float cardUpperLeft;
    
    [Tooltip("カード全体の高さ")]
    [SerializeField] private float cardY = 20.0f;

    
    private float cardBaseX;

    private float centerX;

    Vector2 cardBasePos;

    private void Awake()
    {
        centerX = Screen.width / 2f;
        cardBasePos = new Vector2(centerX, cardY);
        cardBaseX = centerX;
        cardUpperLeft = centerX;
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

            RectTransform pos = card.GetComponent<RectTransform>();

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
        int count = cards.Count;

        if (count == 0) return;//ゼロの時は返す

        //カードが一枚の時は中央に配置する
        if (count==1)
        {
            cards[0].transform.position = cardBasePos;
        }


        else if(count%2==0)
        {
            for(int i=0;i<count;i++)
            {
                BaseCard card = cards[i];
                if (card == null) continue;
                RectTransform pos = card.GetComponent<RectTransform>();
                pos.position= new Vector2(
                    cardBaseX + (i - count / 2) * spacing,
                    cardY
                );
                pos.SetAsLastSibling();
                pos.localRotation = Quaternion.identity;
            }

        }
        else
        {
            for(int i= 0; i < count; i++)
            {
                BaseCard card = cards[i];
                if (card == null) continue;
                RectTransform pos = card.GetComponent<RectTransform>();
                pos.position= new Vector2(
                    cardBaseX + (i - count / 2f) * spacing,
                    cardY
                );
                pos.SetAsLastSibling();
                pos.localRotation = Quaternion.identity;
            }
        }

    }
 
}
