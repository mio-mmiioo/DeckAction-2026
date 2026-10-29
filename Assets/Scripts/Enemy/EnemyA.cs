using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyA : MonoBehaviour
{
    //[Tooltip("移動速度を設定してください")]
    //[SerializeField] public float moveSpeed = 5.0f;

    [Tooltip("ジャンプ力を設定してください")]
    [SerializeField] private float jumpForce = 3.0f;

    private SpriteRenderer spriteRenderer; // 描画関連の情報が
    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数
    private CheckOnGround checkOnGround; // 地面との当たり判定をする
    private CharaAttack charaAttack; // 攻撃の一つ
    private EnemyAStateContext stateContext; // EnemyAのStateを管理する

    private bool isJump = false; // ジャンプするならtrue
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        checkOnGround = GetComponent<CheckOnGround>();
        charaAttack = GetComponent<CharaAttack>();
        stateContext = GetComponent<EnemyAStateContext>();
        stateContext.Init(this, ENEMY_A_STATE.E_A_STATE_WALK);
    }

    void Update()
    {
        stateContext.Update();

        //Walk();

        //// ジャンプ
        //if (Keyboard.current.kKey.wasPressedThisFrame && checkOnGround.onGround == true)
        //{
        //    isJump = true;
        //}

        //// 攻撃
        //if (Keyboard.current.oKey.wasPressedThisFrame)
        //{
        //    charaAttack.Attack();
        //}

    }

    void FixedUpdate()
    {
        Jump();
    }

    /// <summary>
    /// 敵Aのジャンプ処理
    /// </summary>
    private void Jump()
    {
        if (isJump == true)
        {
            isJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Attack()
    {
        stateContext.ChangeState(ENEMY_A_STATE.E_A_STATE_ATTACK);
    }
}
