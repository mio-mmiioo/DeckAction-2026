using UnityEngine;

public class Boss2 : MonoBehaviour
{
    private Boss2StateContext stateContext; // Boss2のStateを管理する

    void Start()
    {
        stateContext = GetComponent<Boss2StateContext>();
        stateContext.Init(this, BOSS_2_STATE.B_2_STATE_MOVE);

    }

    void Update()
    {
        stateContext.Update();
    }

    /// <summary>
    /// 攻撃パターン1
    /// </summary>
    public void Attack1()
    {
        stateContext.ChangeState(BOSS_2_STATE.B_2_STATE_ATTACK_1);
    }

    public void Move()
    {
        stateContext.ChangeState(BOSS_2_STATE.B_2_STATE_MOVE);
    }
}
