using System.Collections.Generic;
using UnityEngine;

public class Boss1StateContext : MonoBehaviour
{
    private IBoss1State currentState; // 現在の状態
    private IBoss1State prevState; // 前回の状態

    Dictionary<BOSS_1_STATE, IBoss1State> stateTable;


    public void Init(Boss1 boss1,BOSS_1_STATE initState)
    {
        //初期化されている場合は戻る
        if(stateTable !=null)
        {
            return;
        }

        Dictionary<BOSS_1_STATE, IBoss1State> table = new()
        {
            { BOSS_1_STATE.B_1_STATE_JUMP, new Boss1StateJump(boss1) },
            { BOSS_1_STATE.B_1_STATE_IDLE, new Boss1StateIdle(boss1) }
        };
        stateTable = table;

        var nextState = stateTable[initState];
        prevState = currentState;
        currentState = nextState;
        currentState.Entry();

    }



    public void ChangeState(BOSS_1_STATE next)
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

    // Update is called once per frame
    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
