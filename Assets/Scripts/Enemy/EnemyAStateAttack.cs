using UnityEngine;

public class EnemyAStateAttack : IEnemyAState
{
    private EnemyA enemyA;
    public ENEMY_A_STATE state => ENEMY_A_STATE.E_A_STATE_ATTACK;
    public EnemyAStateAttack(EnemyA e) => enemyA = e;

    private GameObject player;
    private Vector3 playerPosition; // 呼ばれた時のプレイヤーの位置
    private Rigidbody2D rigidbody2D;

    private bool isEndAttack = false; // 攻撃が終了しているならtrue

    private float jumpHeight = 7.0f; // ジャンプ力
    private const float PLAYER_OFFSET = 1.5f; // プレイヤーの頭付近に着地点を調整するための補正値
    private float direction;
    private float moveSpeed; // 移動速度

    private const float CHARGE_TIME = 5.0f; // 攻撃前のための時間
    private float chargeTimer = 0.0f; // 攻撃の前のため
    private float jumpTime; // ジャンプの時間


    public void Entry()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position; // プレイヤーの位置を取得
        rigidbody2D = enemyA.GetComponent<Rigidbody2D>();
        chargeTimer = CHARGE_TIME;

        // 数値を設定する
        CheckVelocity();
    }

    public void Update()
    {
        // 攻撃前のため
        if (chargeTimer > 0.0f)
        {
            chargeTimer -= Time.deltaTime;
            if (chargeTimer <= 0.0f)
            {
                AttackJump();
            }
            return;
        }

        if (jumpTime > 0.0f)
        {
            jumpTime -= Time.deltaTime;
            rigidbody2D.linearVelocity = new Vector2(direction * moveSpeed, rigidbody2D.linearVelocity.y);
            if (jumpTime <= 0.0f)
            {
                isEndAttack = true;
                rigidbody2D.linearVelocity = new Vector2(0.0f, rigidbody2D.linearVelocity.y);
            }
        }
        // 攻撃が終了した場合、状態を移動へ遷移する
        if (isEndAttack == true)
        {
            enemyA.Move();
        }
    }

    public void Exit()
    {

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
        playerPosition = playerPosition + Vector3.up * PLAYER_OFFSET; // プレイヤーの頭付近
        float gravity = rigidbody2D.gravityScale;
        float heightDistance = playerPosition.y - enemyA.transform.position.y; // 着地点と高さの距離

        float verticalSpeed = Mathf.Sqrt(2.0f * gravity * jumpHeight); // 垂直方向の初速度

        // ジャンプの時間
        jumpTime = (verticalSpeed + Mathf.Sqrt(verticalSpeed * verticalSpeed - 2.0f * gravity * heightDistance)) / gravity;

        // 水平方向の移動速度
        float distance = Mathf.Abs(playerPosition.x - enemyA.transform.position.x);
        moveSpeed = distance / jumpTime;

        // 移動方向
        direction = Mathf.Sign(playerPosition.x - enemyA.transform.position.x);
    }
}
