using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyA : MonoBehaviour
{
    [Tooltip("移動速度を設定してください")]
    [SerializeField] private float moveSpeed = 5.0f;

    [Tooltip("ジャンプ力を設定してください")]
    [SerializeField] private float jumpForce = 3.0f;

    private SpriteRenderer spriteRenderer; // 描画関連の情報が
    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数
    private CheckOnGround checkOnGround; // 地面との当たり判定をする
    private CharaAttack charaAttack; // 攻撃の一つ

    private bool isJump = false; // ジャンプするならtrue
    private bool isRight = false; // 右方向を向いているならtrue

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        checkOnGround = GetComponent<CheckOnGround>();
        charaAttack = GetComponent<CharaAttack>();
    }

    void Update()
    {
        Walk();

        // ジャンプ
        if (Keyboard.current.kKey.wasPressedThisFrame && checkOnGround.onGround == true)
        {
            isJump = true;
        }

        // 攻撃
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            charaAttack.Attack();
        }

    }

    void FixedUpdate()
    {
        Jump();
    }

    /// <summary>
    /// 敵Aの移動処理
    /// </summary>
    private void Walk()
    {
        float direction = 0.0f;
        if (Keyboard.current.jKey.isPressed)
        {
            direction = -1.0f;
            isRight = false;
        }
        else if (Keyboard.current.lKey.isPressed)
        {
            direction = 1.0f;
            isRight = true;
        }
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        // 移動方向によって画像を反転させる
        if (isRight == true)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
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
}
