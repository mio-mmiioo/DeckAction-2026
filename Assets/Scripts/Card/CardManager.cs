using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.CollectionHelper;


public class CardManager : MonoBehaviour
{
    [Tooltip("BaseCardのプレハブ")]
    [SerializeField] private BaseCard baseCard;

    [Tooltip("プレイヤーの手札のTransform")]
    [SerializeField] private Transform playerHand;

    [Tooltip("カード情報のデーターベース")]
    [SerializeField] CardDataBase cardDataBase;

    [Tooltip("使用したカードの表示領域")]
    [SerializeField] GameObject useCardView;

    List<BaseCard> hands = new List<BaseCard>();// プレイヤーの手札のリスト
    Queue<BaseCard> useCards=new Queue<BaseCard>();// 使用済みカードのリスト


    [Tooltip("手札の最大枚数")]
    [SerializeField] private int maxHands;

    private int labelCount; //カードの仮の数字

    private int MAX_USE_CARD; //カードを同時に使える最大枚数

    private HandsSort handsSort;// プレイヤーの手札を並べる

    [SerializeField] private int currentPickCard;// 現在拡大中のカード

    private float drawCooldown;//ドローのクールダウン時間(秒)

    private float cooldownElapsedTime;//経過時間

    /// <summary>
    /// 変数の初期化
    /// </summary>
    void Start()
    {
        drawCooldown = 10f;
        cooldownElapsedTime = 0;
        maxHands = 4;
        MAX_USE_CARD = 4;
        labelCount = 1;
        handsSort = GetComponent<HandsSort>();
        AddHands(maxHands,false);
        Debug.Log("CardManager OK");

        for(int i=0;i<hands.Count;i++)
        {
            hands[i].isPassive = true;
        }

        //currentPickCard = 0;
        hands[currentPickCard].isPick = true;

    }

    /// <summary>
    /// カードの状態を確認する
    /// </summary>
    void Update()
    {
        //時間経過でカードを引く
        if(hands.Count<maxHands)
        {
            cooldownElapsedTime += Time.deltaTime;
            Debug.Log("一秒経過");
            if(cooldownElapsedTime>=drawCooldown)
            {
                AddHands(1, false);
                cooldownElapsedTime = 0f;
            }
        }

        // 手札の状態を確認するfor文
        for (int i=0;i<hands.Count;i++)
        {
            // カードが破棄可能かつ破棄された場合の処理
            if (hands[i].isTrash && hands[i].canTrash)
            {
                Destroy(hands[i].gameObject);
                hands.RemoveAt(i);
                AddHands(1, true);
                Debug.Log("カードを破棄しました");
            }

            // カードが使用されたの場合の処理
            else if (hands[i].isUsed)
           {
                if (useCards.Count < MAX_USE_CARD)
                {
                    useCards.Enqueue(hands[i]);
                    hands[i].transform.SetParent(useCardView.transform);
                    hands.RemoveAt(i);
                    CardSort();
                }
                else
                {
                    hands[i].isUsed = false;
                }
            }

         }
        
    }

    /// <summary>
    /// 基本的な手札の増加関数　
    /// value 増やしたい手札の枚数 
    /// trash 捨てたことでのドローかどうか true:捨てたことでのドロー false:通常のドロー
    /// </summary>
    /// <param name="value"></param>
    public void AddHands(int value, bool trash)
    {
        for(int i=0;i<value;i++)
        {
            BaseCard obj = Instantiate(baseCard, playerHand);

            CardLabel label = obj.GetComponent<CardLabel>();
            string text = labelCount.ToString();
            label.SetName(text);

            labelCount++;

            if (trash)
            {
                obj.canTrash = false;
            }
            else
            {
                obj.canTrash = true;
            }
            hands.Add(obj);
        }
        Debug.Log("CardSort呼び出し前");
        CardSort();
        Debug.Log("CardSort呼び出し後");
    }

    /// <summary>
    /// 使用されたキューの先頭のカードIDを取り出す関数
    /// 0は失敗
    /// </summary>
    /// <returns></returns>
    public int GetUseCard()
    {
        if(useCards.Count!=0)
        {
            BaseCard card = useCards.Dequeue();

            int num = card.cardID;

            Destroy(card.gameObject);

            return num;
        }

        return 0;

        
    }

    /// <summary>
    /// 手札のリストをソートして表示もソートする
    /// </summary>
    private void CardSort()
    { 
        hands.Sort((x,y) => x.cardID-y.cardID);
      
        handsSort.CardViewSort(hands);
    }
}

