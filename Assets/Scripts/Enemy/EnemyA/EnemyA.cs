using UnityEngine;

public class EnemyA : MonoBehaviour
{
    private EnemyAStateContext stateContext; // EnemyAのStateを管理する
    private Animator animator; // アニメーション関連

    void Start()
    {
        stateContext = GetComponent<EnemyAStateContext>();
        stateContext.Init(this, ENEMY_A_STATE.E_A_STATE_MOVE);
        animator = GetComponent<Animator>();
        animator.Play("Idle");
    }

    void Update()
    {
        stateContext.Update();
    }

    public void Attack()
    {
        stateContext.ChangeState(ENEMY_A_STATE.E_A_STATE_ATTACK);
    }

    public void Move()
    {
        stateContext.ChangeState(ENEMY_A_STATE.E_A_STATE_MOVE);
    }
}
