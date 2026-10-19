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

    public float rayLength = 0.5f; // レイの長さ
    public Vector2 moveInput; // 
    private Vector2 slopeNormal; // 斜面の法線
    public bool onGround = false; // 地面に足がついているならtrue

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
        CheckSlope();
        Move();
        //if (groundCheck != null)
        //{
        //    onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        //}
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    private void Walk()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        float direction = 0.0f;
        if (Keyboard.current.aKey.isPressed)
        {
            direction = -1.0f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            direction = 1.0f;
        }
        moveInput = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    void Move()
    {
        if (onGround == true)
        {
            Vector2 slopePerpendicular = Vector2.Perpendicular(slopeNormal).normalized;

            // Vector2.Perpendicularは左に90度回転するから、右移動の時に符号を反転させて調整
            Vector2 moveVelocity = -slopePerpendicular * moveInput.x * moveSpeed;

            // 静止時の滑り落ちを防ぐ
            if (moveInput.x == 0)
            {
                rb.linearVelocity = new Vector2(0, 0);
            }
            else
            {
                rb.linearVelocity = moveVelocity;
            }
        }
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

    void CheckSlope()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

        if (hit)
        {
            onGround = true;
            slopeNormal = hit.normal; // 斜面の法線を取得
        }
        else
        {
            onGround = false;
            slopeNormal = Vector2.up; // 空中にいるときは上
        }
    }

    /// <summary>
    /// Unityエディタ上でプレイヤーの足元にあるCheck Sphereを赤い円で表示する
    /// </summary>
    //private void OnDrawGizmosSelected()
    //{
    //    if (groundCheck != null)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    //    }
    //}
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }
}
