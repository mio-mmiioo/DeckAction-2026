using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// GameManagerのキャラクタークラスにつける
/// エネミーをリストで管理、ターゲット指定するクラス
/// </summary>
public class EnemySetTarget : MonoBehaviour
{
    [SerializeField] private AttackTarget attackTarget;// プレイヤーのアタック先

     List<Transform> enemyList=new List<Transform>();// エネミーのリスト

    private int currentTarget;// 現在のターゲット

    private Transform clickedTarget;// クリックしたターゲット

    void Start()
    {
        currentTarget = 0;
        // Enemyタグを全員リストに入れる
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if(child.CompareTag("Enemy"))
            {
                enemyList.Add(child);
            }

        }
        
        // リストの先頭の敵をデフォルトのターゲットに指定。ヒエラルキー上で一番上
        attackTarget.SetTarget(enemyList[currentTarget]);
    }

    void Update()
    {
        //左クリックの入力をとる(デバッグでの仮実装)
        if(Input.GetMouseButtonDown(0))
        {
            ClickTarget();
        }

        //エネミーリストでnullをすぐに削除
        if(enemyList.RemoveAll(item => item == null)>0)        
        {
            //自動でターゲットの更新
            // 指定してた敵がいなくなったら、リストの先頭を指定する
            if (enemyList.Count > 0)
            {
                currentTarget = 0;
                attackTarget.SetTarget(enemyList[currentTarget]);
            }
        }

        
        
    }

    public void sssm()
    {
        if(currentTarget<enemyList.Count)
        {
            currentTarget++;
            attackTarget.SetTarget(enemyList[currentTarget]);
        }
        
    }

    /// <summary>
    /// クリックからレイを飛ばしてターゲットを決める
    /// </summary>
    private void ClickTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit2d)
        {
            clickedTarget = hit2d.transform;
            for(int i=0;i<enemyList.Count;i++)
            {
                if (enemyList[i]==clickedTarget)
                {
                    currentTarget = i;
                    attackTarget.SetTarget(enemyList[currentTarget]);
                }
            }
        }

    }
        
}
