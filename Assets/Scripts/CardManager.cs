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
    List<Transform> dummyHands = new List<Transform>();// ダミーカードのリスト

    

    void Start()
    {
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
        if(Input.GetKeyDown(KeyCode.U))
        {
            AddHands(1,false);
        }

        for(int i=0;i<hands.Count;i++)
        {
            if (hands[i].isTrash && hands[i].canTrash)
            {
                AddHands(1, hands[i].canTrash);
                Destroy(dummyHands[i].gameObject);
                Destroy(hands[i]);
                dummyHands.RemoveAt(i);
                hands.RemoveAt(i);
                Debug.Log("カードを破棄しました");
            }

            //if (hands[i].isUsed)
            //{

            //}
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
            if(trash)
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

}

