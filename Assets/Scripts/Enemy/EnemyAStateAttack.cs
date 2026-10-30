using UnityEngine;

public class EnemyAStateAttack : IEnemyAState
{
    private EnemyA enemyA;
    public ENEMY_A_STATE state => ENEMY_A_STATE.E_A_STATE_ATTACK;
    public EnemyAStateAttack(EnemyA e) => enemyA = e;

    public void Entry()
    {
        Debug.Log("攻撃範囲に入りました");
    }

    public void Update()
    {


    }

    public void Exit()
    {

    }
}
