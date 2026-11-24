using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBStateContext : MonoBehaviour
{
    private IEnemyBState currentState; // 現在の状態
    private IEnemyBState prevState; // 前回の状態

    Dictionary<ENEMY_B_STATE, IEnemyBState> stateTable;

    public void Init(EnemyB enemyB, ENEMY_B_STATE initState)
    {
        // 初期化されている場合は戻る
        if (stateTable != null)
        {
            return;
        }

        Dictionary<ENEMY_B_STATE, IEnemyBState> table = new()
        {
            { ENEMY_B_STATE.E_B_STATE_MOVE, new EnemyBStateMove(enemyB) }
        };
        stateTable = table;

        var nextState = stateTable[initState];
        prevState = currentState;
        currentState = nextState;
        currentState.Entry();
    }

    public void ChangeState(ENEMY_B_STATE next)
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
        prevState.Exit();
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
