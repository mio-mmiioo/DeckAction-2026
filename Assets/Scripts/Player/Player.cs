using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Tooltip("プレイヤーの移動速度を設定してください")]
    [SerializeField] private float moveSpeed = 5.0f;

    [Tooltip("プレイヤーのジャンプ力を設定してください")]
    [SerializeField] private float jumpForce = 1.0f; // ジャンプ力

    private Rigidbody2D rb; // Rigidbody2Dの情報を取得するための変数
    private CheckOnGround checkOnGround; // 地面との当たり判定をする
    private CharaHp charaHp; // 体力を管理する
    private CharaSetAttackTurn attackTurn;

    private PlayerUseCard playerUseCard;

    private bool isJump = false; // ジャンプするならtrue
    private bool isRight = true; // 右方向を向いているならtrue

    private float DUSH_TIME = 0.1f;
    private float dushToIdle;//ダッシュからアイドルに移行するまでの時間

    private Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkOnGround = GetComponent<CheckOnGround>();
        charaHp = GetComponent<CharaHp>();
        attackTurn = GetComponentInParent<CharaSetAttackTurn>();
        playerUseCard = GetComponentInParent<PlayerUseCard>();
        playerAnimator = GetComponent<Animator>();
        dushToIdle = DUSH_TIME;
    }

    void Update()
    {
        if (charaHp.GetHP() <= 0)
        {
            return;
        }

        if (attackTurn.GetIsAttackTurn() == true)
        {
            playerUseCard.UseCard();
        }
        else
        {
            Walk();
            // ジャンプ
            if (Keyboard.current.spaceKey.wasPressedThisFrame && checkOnGround.onGround == true)
            {
                isJump = true;
            }
        }

        if(checkOnGround.onGround==true)
        {
            playerAnimator.SetBool("IsJump", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJump", true);
        }

        if (!Input.anyKey)
        {
            dushToIdle -= Time.deltaTime;
        }
        else
        {
            dushToIdle = DUSH_TIME;
        }
        
        if(dushToIdle<0)
        {
            playerAnimator.SetBool("IsDush", false);
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
            if(!isJump&&checkOnGround.onGround)
            GetComponent<Animator>().SetBool("IsDush", true);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            direction = 1.0f;
            isRight = true;
            if (!isJump&&checkOnGround.onGround)
            GetComponent<Animator>().SetBool("IsDush", true);
        }
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        // 体の向きに関する部分
        Vector3 scale = transform.localScale;
        if (isRight == true)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * -1.0f;
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
