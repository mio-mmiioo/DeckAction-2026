using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // プレイヤーの移動速度
    [SerializeField] private float jumpForce = 3.0f; // ジャンプ力

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
        if (Keyboard.current.spaceKey.wasPressedThisFrame && checkOnGround.onGround == true)
        {
            isJump = true;
        }
    }

    void FixedUpdate()
    {
        Jump();
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    private void Walk()
    {
        float direction = 0.0f; // 進む方向 -1:左, 1:右
        if (Keyboard.current.aKey.isPressed)
        {
            direction = -1.0f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            direction = 1.0f;
        }
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    /// <summary>
    /// プレイヤーのジャンプ処理
    /// </summary>
    private void Jump()
    {
        if (isJump == true)
        {
            isJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// プレイヤーの弱攻撃
    /// </summary>
    private void JubAttack()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {

        }
    }
}
