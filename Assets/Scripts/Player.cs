using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // プレイヤーの移動速度
    [SerializeField] private float jumpForce = 3.0f; // ジャンプ力

    [SerializeField] private Transform groundCheck; // プレイヤーの足元に置くCheck Sphere
    [SerializeField] private LayerMask groundLayer; // 地面として認識するレイヤー

    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数
    private float checkRadius = 0.2f; // 足元のCheck Sphereの大きさ
    private bool onGround = false; // 地面に足がついているならtrue

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }

    void FixedUpdate()
    {
        if (groundCheck != null)
        {
            onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        }
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    private void Walk()
    {
        float direction = 0.0f;
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
        if (Keyboard.current.spaceKey.wasPressedThisFrame && onGround == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Unityエディタ上でプレイヤーの足元にあるCheck Sphereを赤い円で表示する
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
        
}
