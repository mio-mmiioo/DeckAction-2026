using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyA : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // 敵Aの移動速度
    [SerializeField] private float jumpForce = 3.0f; // ジャンプ力
    [SerializeField] private CharaAttack charaAttack; // 攻撃の一つ

    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数
    private CheckOnGround checkOnGround; // 地面との当たり判定をする

    private bool isJump = false; // ジャンプするならtrue

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkOnGround = GetComponent<CheckOnGround>();
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
        }
        else if (Keyboard.current.lKey.isPressed)
        {
            direction = 1.0f;
        }
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
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
