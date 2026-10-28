using UnityEngine;

public class EnemyAStateIdle : IEnemyAState
{
    EnemyA enemyA;
    public ENEMY_A_STATE state => ENEMY_A_STATE.E_A_STATE_IDLE;
    public EnemyAStateIdle(EnemyA e) => enemyA = e;

    public void Entry()
    {

    }

    public void Update()
    {

    }

    public void Exit()
    {

    }
}
