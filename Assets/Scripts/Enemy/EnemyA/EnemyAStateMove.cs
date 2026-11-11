using Unity.VisualScripting;
using UnityEngine;

public class EnemyAStateMove : IEnemyAState
{
    private const float WAIT_TIME = 1.0f; // 着地後に止まる時間
    private const float MOVE_SPEED = 0.2f; // 移動速度
    private const float JUMP_HEIGHT = 4.0f; // ジャンプ力

    private EnemyA enemyA;
    public ENEMY_A_STATE state => ENEMY_A_STATE.E_A_STATE_MOVE;

    private Rigidbody2D rigidbody2D; // 敵Aのrigidbody2D
    private SpriteRenderer spriteRenderer; // 敵AのspriteRenderer
    private Animator animator;
    private CheckOnGround checkOnGround; // 地面との当たり判定をする
    private CheckDistancePlayer checkDistancePlayer; // プレイヤーとの距離を確認
    private GameObject player; // プレイヤーオブジェクト

    private bool isRight = true; // 右を向いているならtrue
    private bool isJump = false; // ジャンプするならtrue
    private bool isFalling = false;
    private bool isPrevOnGround = false;
    private float waitTimer = WAIT_TIME; // 着地後に止まる時間を管理するタイマー

    private bool isStartMove; // 動いていいならtrue

    /// <summary>
    /// 敵を設定
    /// </summary>
    /// <param name="e">EnemyA</param>
    public EnemyAStateMove(EnemyA e)
    {
        enemyA = e;
    }

    public void Entry()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = enemyA.GetComponent<Rigidbody2D>();
        spriteRenderer = enemyA.GetComponent<SpriteRenderer>();
        animator = enemyA.GetComponent<Animator>();
        checkOnGround = enemyA.GetComponent<CheckOnGround>();
        checkDistancePlayer = enemyA.GetComponent<CheckDistancePlayer>();

        isStartMove = false;
        waitTimer = WAIT_TIME;
    }

    public void Update()
    {
        // 移動処理を開始してよいかの判断
        {
            if (checkOnGround.onGround == true)
            {
                isStartMove = true;
            }
            if (isStartMove == false)
            {
                return;
            }
        }
        // 遷移の条件を確認
        // 攻撃可能範囲内にいるなら、状態を攻撃に変える
        if (checkDistancePlayer.IsPlayerInAttackArea() == true && checkOnGround.onGround == true)
        {
            enemyA.Attack();
            return;
        }

        // 着地直後の場合
        if (checkOnGround.onGround == true)
        {
            isFalling = false;
            if (isPrevOnGround == false)
            {
                waitTimer = WAIT_TIME;
                rigidbody2D.linearVelocity = new Vector2(0.0f, rigidbody2D.linearVelocity.y);
                animator.SetTrigger("Idle");
            }
        }
        isPrevOnGround = checkOnGround.onGround;

        // ジャンプ後の停止中の処理
        if (waitTimer > 0.0f)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0.0f)
            {
                isJump = true;
            }
            return;
        }

        // 移動処理
        Jump();
        Walk();


        // 着地アニメーションに切り替える判定
        if (checkOnGround.onGround == false && isFalling == false)
        {
            if (rigidbody2D.linearVelocity.y < 0.0f)
            {
                isFalling = true;
                animator.SetTrigger("Landing");
            }
        }
    }

    public void Exit()
    {
        animator.SetTrigger("Idle");
    }

    /// <summary>
    /// 敵Aの移動処理
    /// </summary>
    private void Walk()
    {
        float direction = 0.0f;
        Vector3 playerPos = player.transform.position; // プレイヤーの方向から、移動方向を確認する
        
        // プレイヤーの左側にいる場合
        if (enemyA.transform.position.x < playerPos.x)
        {
            direction = 1.0f;
            isRight = true;
        }
        else
        {
            direction = -1.0f;
            isRight = false;
        }
        rigidbody2D.linearVelocity = new Vector2(direction * MOVE_SPEED, rigidbody2D.linearVelocity.y);

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
            isFalling = false;
            rigidbody2D.AddForce(Vector2.up * JUMP_HEIGHT, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }
}
