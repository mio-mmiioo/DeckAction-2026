using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // プレイヤーの移動速度
    [SerializeField] private float jumpForce = 3.0f; // ジャンプ力
    [SerializeField] private LayerMask groundLayer; // 地面として認識するレイヤー

    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数

    private Vector2 moveInput; // 入力された移動方向
    private float rayLength = 1.2f; // レイの長さ
    private float direction = 0.0f; // 移動方向
    private bool onGround = false; // 地面に足がついているならtrue
    private bool isJump = false; // ジャンプするならtrue

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Walk();

        if (Keyboard.current.spaceKey.wasPressedThisFrame && onGround == true)
        {
            isJump = true;
        }
    }

    void FixedUpdate()
    {
        CheckGround();

        // 坂道に対する対応、入力がない場合は静止させる
        if (direction == 0)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        Jump();
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    private void Walk()
    {
        float d = 0.0f; // 進む方向 -1:左, 1:右
        if (Keyboard.current.aKey.isPressed)
        {
            d = -1.0f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            d = 1.0f;
        }
        direction = d;
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
    /// レイキャストで地面との当たり判定を行う
    /// </summary>
    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        if (hit)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }
}
