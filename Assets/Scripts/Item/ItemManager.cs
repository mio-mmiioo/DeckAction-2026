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

    [Tooltip("プレイヤーのポジションを設定してください")]
    [SerializeField] private Transform playerTransform;// プレイヤーの位置

    [SerializeField]  private List<ItemCard> itemCardList = new List<ItemCard>(); // フィールド上にあるアイテムのリスト

    [SerializeField] private float itemSpawnTimer; // アイテムが出現するまでのタイマー

    private int maxItem; // フィール上にあるアイテムの最大数
    private float ITEM_SPAWN_TIME=4.0f; // 3秒に一回
    
    private Vector2 spawnPosition;// アイテムを生成する位置
    private float spawnHeight=-1.5f;// 生成の高さ

    private float minDistancePlayer;// プレイヤーから最低限の距離

    private float borderPadding;// 画面端で生成しないための余白

    private float minWidthPos;// カメラの左端

    private float maxWidthPos;// カメラの右端


    private TurnManager turnManager;

    void Start()
    {
        maxItem = 4;
        itemSpawnTimer = ITEM_SPAWN_TIME;
        turnManager=FindAnyObjectByType<TurnManager>();
        minDistancePlayer = 3.0f;
        borderPadding = 0.5f;
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        minWidthPos = bottomLeft.x + borderPadding;
        maxWidthPos = topRight.x - borderPadding;


    }
    
    void Update()
    {
        // 攻撃ターンじゃないときのみ生成する 攻撃ターンになったらリストを空にする
        if(turnManager.GetCurrentTurn()==TurnManager.TURN_TYPE.PLAYER_TURN)
        {
            for(int i=0;i<itemCardList.Count;i++)
            {
                Destroy(itemCardList[i].gameObject);
                itemCardList.RemoveAt(i);
            }
        }
        else if (turnManager.GetCurrentTurn() == TurnManager.TURN_TYPE.ENEMY_TURN)
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
        // 上手く生成できなかっらやり直す回数(無限ループ防止)
        int maxAttempts = 10;

        // アイテムの最大数より小さかったら生成開始
        if (itemCardList.Count <= maxItem)
        {
            for (int i = 0; i < maxAttempts; i++)
            {
                // ランダムなX軸を決める
                float rndPositon = Random.Range(minWidthPos, maxWidthPos);

                //生成場所
                spawnPosition = new Vector3(rndPositon, spawnHeight, 0);


                // プレイヤーと近すぎるたらやり直し
                float distanceToPlayer = Vector2.Distance(new Vector2(rndPositon, playerTransform.position.y), playerTransform.position);
                if (distanceToPlayer < minDistancePlayer)
                {
                    continue;
                }


                // アイテムを生成してリストに入れる
                ItemCard item = Instantiate(itemCard, spawnPosition, Quaternion.identity);
                itemCardList.Add(item);
                return;
            }
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
