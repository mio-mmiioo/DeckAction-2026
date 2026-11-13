using System.Collections.Generic;
using UnityEngine;

public class Boss2StateContext : MonoBehaviour
{
    private IBoss2State currentState; // 現在の状態
    private IBoss2State prevState; // 前回の状態

    Dictionary<BOSS_2_STATE, IBoss2State> stateTable;

    public void Init(Boss2 boss2, BOSS_2_STATE initState)
    {
        // 初期化されている場合は戻る
        if (stateTable != null)
        {
            Debug.Log("ボス2のステートの初期化がすでに行われている");
            return;
        }

        Dictionary<BOSS_2_STATE, IBoss2State> table = new()
        {
            { BOSS_2_STATE.B_2_STATE_MOVE, new Boss2StateMove(boss2) },
            { BOSS_2_STATE.B_2_STATE_ATTACK_1, new Boss2StateAttack1(boss2) }
        };
        stateTable = table;
        Debug.Log("ボス2のステートの初期化");
        var nextState = stateTable[initState];
        prevState = currentState;
        currentState = nextState;
        currentState.Entry();
    }

    public void ChangeState(BOSS_2_STATE next)
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
