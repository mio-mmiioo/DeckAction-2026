using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2StateAttack4 : IBoss2State
{
    private Boss2 boss2;
    public BOSS_2_STATE state => BOSS_2_STATE.B_2_STATE_ATTACK_4;

    private GameObject boss2Attack;
    private Vector3 createPosition;
    private Vector3 offset1 = new Vector3(-2.0f, -2.0f, 0.0f);
    private Vector3 offset2 = new Vector3(-2.5f, -2.5f, 0.0f);

    //private const float CREATE_TIME = 3.0f; // 生成時間
    private const float WAIT_TIME = 2.0f; // 生成後の待ち時間
    private float timer = 0.0f; // タイマー

    /// <summary>
    /// 敵を設定
    /// </summary>
    /// <param name="e">Boss2</param>
    public Boss2StateAttack4(Boss2 e)
    {
        boss2 = e;
        boss2Attack = GameObject.Find("Boss2Attack");
    }

    public void Entry()
    {
        Boss2CreateEnemy create = boss2Attack.GetComponent<Boss2CreateEnemy>();
        create.CreateEnemyB(boss2.transform.position + offset1, boss2.transform.parent);
        create.CreateEnemyB(boss2.transform.position + offset2, boss2.transform.parent);
        timer = WAIT_TIME;
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            boss2.Move();
        }
    }

    public void Exit()
    {
    }
}
