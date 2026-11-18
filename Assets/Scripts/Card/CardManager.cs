using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class CardManager : MonoBehaviour
{
    [Tooltip("カード情報のデーターベース")]
    [SerializeField] CardDataBase cardDataBase;

    [Tooltip("BaseCardのプレハブ")]
    [SerializeField] private BaseCard baseCard;

    [Tooltip("プレイヤーの手札のTransform")]
    [SerializeField] private Transform playerHand;

    [Tooltip("使用したカードの表示領域")]
    [SerializeField] GameObject useCardView;

    [SerializeField] PlayerUseCard playerUseCard;

    List<BaseCard> hands = new List<BaseCard>();// プレイヤーの手札のリスト
    Queue<BaseCard> useCards = new Queue<BaseCard>();// 使用済みカードのリスト

    [Tooltip("手札の最大枚数")]
    [SerializeField] private int maxHands;

    private int labelCount; //カードの仮の数字

    private int MAX_USE_CARD; //カードを同時に使える最大枚数

    private HandsSort handsSort;// プレイヤーの手札を並べる

    [SerializeField] private int currentPickCard;// 現在拡大中のカード

    private float drawCooldown;//ドローのクールダウン時間(秒)

    private float cooldownElapsedTime;//経過時間

    // カードのパラメーターの確率用の変数
    [SerializeField] private float[] cardPopRate;// カードの出現率

    [SerializeField] private float[] cardRarityRate = { 55, 30, 10, 5 };// カードのレアリティの出現率

    [SerializeField]
    private float maxRarityRate;// カードのレアリティの最大値

    private float maxRate;

    CardParameterData cardParameterData = new CardParameterData();// カードのパラメータを格納する構造体

    /// <summary>
    /// 変数の初期化
    /// </summary>
    void Start()
    {
        CalculationCardRarity();
        CalculationCardRate();

        drawCooldown = 3f;
        cooldownElapsedTime = 0;
        maxHands = 4;
        MAX_USE_CARD = 4;
        labelCount = 1;
        handsSort = GetComponent<HandsSort>();
        AddHands(maxHands, false);
        Debug.Log("CardManager OK");

        for (int i = 0; i < hands.Count; i++)
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
        if (hands.Count < maxHands)
        {
            cooldownElapsedTime += Time.deltaTime;
            Debug.Log("一秒経過");
            if (cooldownElapsedTime >= drawCooldown)
            {
                AddHands(1, false);
                cooldownElapsedTime = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            AddHands(1, false);
        }

        // 手札の状態を確認するfor文
        for (int i = 0; i < hands.Count; i++)
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
                    playerUseCard.UseCard();
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
        for (int i = 0; i < value; i++)
        {
            BaseCard obj = Instantiate(baseCard, playerHand, false);
            CardLabel label = obj.GetComponent<CardLabel>();
            string text = labelCount.ToString();

            SetCardParametor();
            obj.Initialize(cardParameterData);


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
    public CardParameterData GetUseCard()
    {
        CardParameterData param=new CardParameterData(0,0,0,0);
        if (useCards.Count != 0)
        {
            BaseCard card = useCards.Dequeue();

            param = card.GetCardParameter();

            Destroy(card.gameObject);

        }


        return param;

    }


    /// <summary>
    /// 手札のリストをソートして表示もソートする
    /// </summary>
    private void CardSort()
    {
        hands.Sort((x, y) => x.cardID - y.cardID);

        handsSort.CardViewSortMedian(hands);
    }


    /// <summary>
    /// カードのパラメーターを決める
    /// </summary>
    private void SetCardParametor()
    {
        cardParameterData.cardType = DetermineCardType();
        cardParameterData.cardDamage = SetCardRandomDamage(cardParameterData.cardType);
        cardParameterData.cardRarity = DetermineCardRarity();
        cardParameterData.cardAbility = DetermineCardAbility(cardParameterData.cardType, cardParameterData.cardRarity);
    }


    /// <summary>
    /// カードタイプの確率を事前に計算する
    /// </summary>
    private void CalculationCardRate()
   {
        maxRate = 0;
        cardPopRate = new float[cardDataBase.CardData.Count-1];
        for (int i = 1; i < cardDataBase.CardData.Count; i++)
        {
            maxRate += cardDataBase.CardData[i].rate;
            cardPopRate[i-1] = maxRate;
        }
    }


    /// <summary>
    /// カードのレア度を計算する
    /// </summary>
    private void CalculationCardRarity()
    {
        maxRarityRate = 0;
        for (int i = 0; i < cardRarityRate.Length; i++)
        {
            maxRarityRate += cardRarityRate[i];
            cardRarityRate[i] = maxRarityRate;
        }
    }

    /// <summary>
    /// 確率からカードタイプを決定する
    /// </summary>
    /// <returns></returns>
    private int DetermineCardType()
    {
        float random = Random.Range(0, maxRate);
        for (int i = 0; i < cardPopRate.Length; i++)
        {
            if (random < cardPopRate[i])
            {
                return i+1;
            }
        }

        return 0;
    }

    /// <summary>
    /// カードの攻撃力をランダムに決定する
    /// 最低値と最大値の間からランダムに決定する
    /// </summary>
    /// <param name="cardType"></param>
    /// <returns></returns>
    private int SetCardRandomDamage(int cardType)
    {
        int random = Random.Range(cardDataBase.CardData[cardType].minDamage, cardDataBase.CardData[cardType].maxDamage);
        return random;
    }


    /// <summary>
    /// カードのレア度を決定する
    /// </summary>
    /// <returns></returns>
    private int DetermineCardRarity()
    {
        float random = Random.Range(0, maxRarityRate);
        for (int i = 0; i < cardRarityRate.Length; i++)
        {
            if (random < cardRarityRate[i])
            {
                return i+1;
            }
        }
        return 0;
    }


    private int DetermineCardAbility(int cardType,int cardRarity)
    {
        switch (cardRarity)
        {
            case 0:
                return 0;
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 3;
        }

        return 0;
    }
}


