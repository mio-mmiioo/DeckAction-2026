using UnityEngine;

public class EnemyA : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // 描画関連の情報が
    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数
    private CheckOnGround checkOnGround; // 地面との当たり判定をする
    private EnemyAStateContext stateContext; // EnemyAのStateを管理する
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        checkOnGround = GetComponent<CheckOnGround>();
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
