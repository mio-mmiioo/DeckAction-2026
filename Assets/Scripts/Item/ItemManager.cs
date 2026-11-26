using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの生成や、管理をするクラス
/// </summary>
public class ItemManager : MonoBehaviour
{

    [Tooltip("アイテムカードのプレハブを設定してください")]
    [SerializeField] private ItemCard itemCard;

    [SerializeField]  private List<ItemCard> itemCardList = new List<ItemCard>(); // フィールド上にあるアイテムのリスト

    private int maxItem; // フィール上にあるアイテムの最大数
    private float ITEM_SPAWN_TIME=3.0f; // 3秒に一回
    [SerializeField] private float itemSpawnTimer; // アイテムが出現するまでのタイマー
    private Vector2 spawnPosition;// アイテムを生成する位置

    private float spawnHeight=-1.7f;// 生成の高さ

    private float spawnSpace;// 生成の横の間隔

    private CharaSetAttackTurn charaSetAttack;

    void Start()
    {
        maxItem = 4;
        itemSpawnTimer = ITEM_SPAWN_TIME;
        charaSetAttack = FindAnyObjectByType<CharaSetAttackTurn>();
    }
    
    void Update()
    {
        // 攻撃ターンじゃないときのみ生成する 攻撃ターンになったらリストを空にする
        if(charaSetAttack.GetIsAttackTurn()==true)
        {
            for(int i=0;i<itemCardList.Count;i++)
            {
                Destroy(itemCardList[i].gameObject);
                itemCardList.RemoveAt(i);
            }
        }
        else
        {
            //3秒に一度、出現するか判定を取る
            if (itemSpawnTimer > 0)
            {
                itemSpawnTimer -= Time.deltaTime;
            }
            else
            {
                ItemCardJenarate();
                itemSpawnTimer = ITEM_SPAWN_TIME;
            }
        }

        //アイテムカードにnullがあったら消す
        itemCardList.RemoveAll(item => item == null);

    }

    /// <summary>
    /// アイテムカードの生成をする関数
    /// </summary>
    private void ItemCardJenarate()
    {
        if (itemCardList.Count <= maxItem)
        {
            int rndPositon = Random.Range(0, 20);


            spawnPosition = new Vector3(rndPositon, spawnHeight, 0);

            // アイテムを生成してリストに入れる
            ItemCard item = Instantiate(itemCard, spawnPosition, Quaternion.identity);
            itemCardList.Add(item);
        }
    }

    /// <summary>
    /// 座標を指定してアイテムを生成する 例：敵の攻撃でのカード生成など
    /// </summary>
    /// <param name="pos"></param>
    public void SetSpawnItemCard(Vector3 pos)
    {
        ItemCard item = Instantiate(itemCard, pos, Quaternion.identity);

        itemCardList.Add(item);
    }
}
