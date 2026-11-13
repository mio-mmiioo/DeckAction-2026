using UnityEngine;
using UnityEngine.Rendering;

public class Boss1 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // 描画関連の情報が
    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数
    private CheckOnGround checkOnGround; // 地面との当たり判定をする
    private Animator animator;
    private Boss1StateContext stateContext;//Boss1のStateを管理する

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        checkOnGround = GetComponent<CheckOnGround>();
        stateContext = GetComponent<Boss1StateContext>();
        stateContext.Init(this, BOSS_1_STATE.B_1_STATE_IDLE);
        animator = GetComponent<Animator>();
        animator.Play("Idle");

    }

    // Update is called once per frame
    void Update()
    {
        stateContext.Update();
    }

    public void Jump()
    {
        stateContext.ChangeState(BOSS_1_STATE.B_1_STATE_JUMP);
    }

    public void Idle()
    {
        stateContext.ChangeState(BOSS_1_STATE.B_1_STATE_IDLE);
    }

}
