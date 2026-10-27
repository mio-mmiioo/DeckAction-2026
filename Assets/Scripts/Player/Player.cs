using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // プレイヤーの移動速度
    [SerializeField] private float jumpForce = 3.0f; // ジャンプ力
    [SerializeField] private PlayerAttack playerAttack; // 攻撃を管理する

    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数
    private CheckOnGround checkOnGround; // 地面との当たり判定をする
    private PlayerAttackType attackType; // 攻撃の種類

    private bool isJump = false; // ジャンプするならtrue
    public bool isRight = true; // 右方向を向いているならtrue

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkOnGround = GetComponent<CheckOnGround>();
        attackType = GetComponent<PlayerAttackType>();
    }

    void Update()
    {
        Walk();

        // ジャンプ
        if (Keyboard.current.spaceKey.wasPressedThisFrame && checkOnGround.onGround == true)
        {
            isJump = true;
        }

        attackType.SetCardID(); // 攻撃の種類をセット

        // 攻撃
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            playerAttack.Attack();
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
            isRight = false;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            direction = 1.0f;
            isRight = true;
        }
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        // 体の向きに関する部分
        Vector3 scale = transform.localScale;
        if (isRight == true)
        {
            scale.x = 1.0f;
        }
        else
        {
            scale.x = -1.0f;
        }
        transform.localScale = scale;
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
}
