using NUnit.Framework;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using System.Collections.Generic;

public class PlayerCombo : MonoBehaviour
{
    [SerializeField] CardManager cardManager;// カードマネージャ

    private const float ATTACK_TIME=1.0f; // 攻撃の秒数制限
    [SerializeField] private float attackTimer;// 次の攻撃までのタイマー

    private int prevCardID;// 前回のカード
    private int currentCardID;// 現在のカード
    [SerializeField] private int comboCount; //コンボ数
    private bool isAttack;  //攻撃判定の有無

    private List<int> comboList = new List<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTimer = ATTACK_TIME;
        currentCardID = 0;
        prevCardID = 0;
    }

    /// <summary>
    /// 攻撃可能か、数値を返す関数
    /// </summary>
    /// <returns></returns>
    public (int cardID,int comboCount,bool isAttack) ComboSet()
    {
        isAttack = false;

        // 攻撃可能かどうかの判定
        if (currentCardID == 0 || attackTimer<0)
        {
            ComboJudge();
            attackTimer = ATTACK_TIME;

        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
        return (currentCardID,comboCount,isAttack);
    }

    /// <summary>
    /// コンボが成立するかどうかを判定する
    /// </summary>
  private void ComboJudge()
    {
        currentCardID = cardManager.GetUseCard();// 使用したカードのIDを取得する

        // コンボ判定
        if (currentCardID != 0)
        {
            if(currentCardID!=prevCardID)
            {
                comboCount = 0;
            }
            else if(currentCardID==prevCardID)
            {
                comboCount++;
            }

            
            prevCardID = currentCardID;
            isAttack = true;
        }
        else
        {
            comboCount = 0;
        }

    }
}
