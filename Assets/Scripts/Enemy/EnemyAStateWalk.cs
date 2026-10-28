using UnityEngine;

public class EnemyAStateWalk : IEnemyAState
{
    EnemyA enemyA;
    public ENEMY_A_STATE state => ENEMY_A_STATE.E_A_STATE_IDLE;
    public EnemyAStateWalk(EnemyA e) => enemyA = e;

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
