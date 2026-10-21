using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.CollectionHelper;

public class CardManager : MonoBehaviour
{
    [SerializeField] BaseCard baseCard;// BaseCardのプレハブ
    [SerializeField] GameObject dummyCardPrefab;// DummyCardのプレハブ
    [SerializeField] Transform playerHand;// プレイヤーの手札のTransform

    [SerializeField] HorizontalLayoutGroup layoutGroup = null;// ダミーカード整列用HorizontallLayoutGroup

    List<BaseCard> hands = new List<BaseCard>();// プレイヤーの手札のリスト
    Queue<BaseCard> useCards=new Queue<BaseCard>();// 使用済みカードのリスト

    List<Transform> dummyHands = new List<Transform>();// ダミーカードのリスト
    private int labelCount;//カードの仮の数字
    

    void Start()
    {
        labelCount = 1;
        AddHands(4,false);
        Debug.Log("CardManager OK");
        for(int i=0;i<hands.Count;i++)
        {
            hands[i].isPassive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用の手札増加処理
        if (Input.GetKeyDown(KeyCode.U))
        {
            AddHands(1,false);
        }


        // 手札の状態を確認するfor文
        for(int i=0;i<hands.Count;i++)
        {
            // カードが破棄可能かつ破棄された場合の処理
            if (hands[i].isTrash && hands[i].canTrash)
            {
                AddHands(1, hands[i].canTrash);
                Destroy(dummyHands[i].gameObject);
                Destroy(hands[i]);
                dummyHands.RemoveAt(i);
                hands.RemoveAt(i);
                Debug.Log("カードを破棄しました");
            }
            // カードが使用されたの場合の処理
            else if (hands[i].isUsed)
           {
               useCards.Enqueue(hands[i]);
               dummyHands.RemoveAt(i);
               hands.RemoveAt(i);
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
            GameObject dummyObj= Instantiate(dummyCardPrefab, playerHand);
            BaseCard obj = Instantiate(baseCard, dummyObj.transform);

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
            dummyHands.Add(dummyObj.transform);
            hands.Add(obj);
            ApplyLayout();
        }
        
    }

    /// <summary>
	/// レイアウトの自動整列機能を即座に適用する
	/// </summary>
	public void ApplyLayout()
    {
        layoutGroup.CalculateLayoutInputHorizontal();
        layoutGroup.SetLayoutHorizontal();
    }

    public BaseCard GetUseCard()
    {
        if(useCards.Count!=0)
        {
            BaseCard used = useCards.Dequeue();


            return used;
        }

        return null;

        
    }

}

