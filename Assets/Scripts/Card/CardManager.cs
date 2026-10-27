using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.CollectionHelper;


public class CardManager : MonoBehaviour
{
    [SerializeField] private BaseCard baseCard;// BaseCardのプレハブ
    
    [SerializeField] private Transform playerHand;// プレイヤーの手札のTransform

    [SerializeField] PlayerHands playerHands;//プレイヤーの手札を並べる

    [SerializeField] CardDataBase cardDataBase;// カード情報のデーターベース

    List<BaseCard> hands = new List<BaseCard>();// プレイヤーの手札のリスト
    Queue<BaseCard> useCards=new Queue<BaseCard>();// 使用済みカードのリスト

    List<Transform> dummyHands = new List<Transform>();// ダミーカードのリスト
    private int labelCount; //カードの仮の数字

    private int MAX_USE_CARD; //カードを同時に使える最大枚数

    [SerializeField] private int nowPickCard;// 現在拡大中のカード

    void Start()
    {
        MAX_USE_CARD = 4;
        labelCount = 1;
        AddHands(4,false);
        Debug.Log("CardManager OK");
        for(int i=0;i<hands.Count;i++)
        {
            hands[i].isPassive = true;
        }
        nowPickCard = 0;
        hands[nowPickCard].isPick = true;
    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用の手札増加処理
        if (Input.GetKeyDown(KeyCode.U))
        {
            AddHands(1,false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            testCardUP();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            CardSort();
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
                    Destroy(hands[i].gameObject);
                    hands.RemoveAt(i);
                    CardSort();
                }
                else
                {
                    hands[i].isUsed = false;
                }
            }

         }

        PickUpCard();
        
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
    /// 使用されキューの先頭のカードIDを取り出す関数
    /// 0は失敗
    /// </summary>
    /// <returns></returns>
    public int GetUseCard()
    {
        if(useCards.Count!=0)
        {
            BaseCard card = useCards.Dequeue();

            int num = card.cardID;

            return num;
        }

        return 0;

        
    }

    private void CardSort()
    { 
        hands.Sort((x,y) => x.cardID-y.cardID);
      
        playerHands.CardViewSort(hands);
    }

    private void testCardUP()
    {
        Vector3 pos = hands[0].transform.position;

        pos.y += 10;
        pos.x += -10;
        hands[0].transform.position = pos;
    }

    private void PickUpCard()
    {
        int nextPick;
        nextPick = nowPickCard;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(nowPickCard>0)
            nextPick=nowPickCard--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (nowPickCard < hands.Count)
                nextPick=nowPickCard++;
        }

        if (nowPickCard != nextPick)
        {
            hands[nextPick].isPick = true;
            hands[nowPickCard].isPick = false;

            nowPickCard = nextPick;
        }

    }



}

