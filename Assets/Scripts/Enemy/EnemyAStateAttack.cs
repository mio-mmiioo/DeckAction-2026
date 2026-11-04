using UnityEngine;

public class EnemyAStateAttack : IEnemyAState
{
    private EnemyA enemyA;
    public ENEMY_A_STATE state => ENEMY_A_STATE.E_A_STATE_ATTACK;
    public EnemyAStateAttack(EnemyA e) => enemyA = e;

    private GameObject player;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private CharaColor charaColor; // 色を変化させる

    private bool isEndAttack = false; // 攻撃が終了しているならtrue

    private float jumpHeight = 7.0f; // ジャンプ力
    private const float PLAYER_OFFSET = 1.5f; // プレイヤーの頭付近に着地点を調整するための補正値
    private float direction; // 移動方向
    private float moveSpeed; // 移動速度

    private const float CHARGE_TIME = 5.0f; // 攻撃前のための時間
    private float chargeTimer = 0.0f; // 攻撃の前のため
    private float jumpTime; // ジャンプの時間

    public void Entry()
    {
        Debug.Log("敵A：Attack開始");
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = enemyA.GetComponent<Rigidbody2D>();
        spriteRenderer = enemyA.GetComponent<SpriteRenderer>();
        charaColor = enemyA.GetComponent<CharaColor>();
        chargeTimer = CHARGE_TIME;

        // 数値を設定する
        CheckVelocity();
    }

    public void Update()
    {
        //SetSpriteFlip();

        // 攻撃前のため
        if (chargeTimer > 0.0f)
        {
            chargeTimer -= Time.deltaTime;
            float rate = (1.0f - chargeTimer / CHARGE_TIME); // 割合
            charaColor.ChargeAttack(rate); // ための時に色を変化させる

            if (chargeTimer <= 0.0f)
            {
                charaColor.ResetColor();
                AttackJump();
            }
            return;
        }

        jumpTime -= Time.deltaTime;
        if (jumpTime > 0.0f)
        {
            rigidbody2D.linearVelocity = new Vector2(direction * moveSpeed, rigidbody2D.linearVelocity.y);
        }
        else
        {
            isEndAttack = true;
            rigidbody2D.linearVelocity = new Vector2(0.0f, rigidbody2D.linearVelocity.y);
        }
        // 攻撃が終了した場合、状態を移動へ遷移する
        if (isEndAttack == true)
        {
            SetSpriteFlip();
            enemyA.Move();
        }
    }

    public void Exit()
    {
        Debug.Log("敵A：Attack終了");
    }

    private void AttackJump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }

    /// <summary>
    /// 移動速度と移動方向を求める
    /// </summary>
    private void CheckVelocity()
    {
        Vector3 playerPosition = player.transform.position + Vector3.up * PLAYER_OFFSET; // プレイヤーの位置を取得
        float gravity = Mathf.Abs(Physics2D.gravity.y * rigidbody2D.gravityScale); // 重力の取得
        float heightDistance = playerPosition.y - enemyA.transform.position.y; // 着地点と高さの距離

        float verticalSpeed = Mathf.Sqrt(2.0f * gravity * jumpHeight); // 垂直方向の初速度
        jumpTime = (verticalSpeed + Mathf.Sqrt(verticalSpeed * verticalSpeed - 2.0f * gravity * heightDistance)) / gravity; // ジャンプの時間

        // 水平方向の移動速度
        float distance = Mathf.Abs(playerPosition.x - enemyA.transform.position.x);
        moveSpeed = distance / jumpTime;

        // 移動方向
        direction = Mathf.Sign(playerPosition.x - enemyA.transform.position.x);
    }

    /// <summary>
    /// プレイヤーの位置から画像の向きを設定する
    /// </summary>
    private void SetSpriteFlip()
    {
        Vector3 playerPos = player.transform.position; // プレイヤーの位置を取得
        // プレイヤーの左側にいる場合
        if (enemyA.transform.position.x < playerPos.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
