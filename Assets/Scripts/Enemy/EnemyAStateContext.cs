using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//参考にしているページ
//https://takap-tech.com/entry/2023/07/23/174149

public class EnemyAStateContext : MonoBehaviour
{
    private IEnemyAState currentState; // 現在の状態
    private IEnemyAState prevState; // 前回の状態

    Dictionary<ENEMY_A_STATE, IEnemyAState> stateTable;

    public void Init(EnemyA enemyA, ENEMY_A_STATE initState)
    {
        // 初期化されている場合は戻る
        if (stateTable != null)
        {
            return;
        }

        Dictionary<ENEMY_A_STATE, IEnemyAState> table = new()
        {
            { ENEMY_A_STATE.E_A_STATE_IDLE, new EnemyAStateIdle(enemyA) },
            { ENEMY_A_STATE.E_A_STATE_ATTACK, new EnemyAStateAttack(enemyA) },
            { ENEMY_A_STATE.E_A_STATE_MOVE, new EnemyAStateMove(enemyA) }
        };
        stateTable = table;

        var nextState = stateTable[initState];
        prevState = currentState;
        currentState = nextState;
        currentState.Entry();
    }

    public void ChangeState(ENEMY_A_STATE next)
    {
        if (stateTable == null)
        {
            return;
        }
        if (currentState == null || currentState.state == next)
        {
            return;
        }

        var nextState = stateTable[next];
        prevState = currentState;
        currentState = nextState;
        currentState.Entry();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
