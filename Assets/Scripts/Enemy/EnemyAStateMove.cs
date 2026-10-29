using UnityEngine;

public class EnemyAStateMove : IEnemyAState
{
    private const float WAIT_TIME = 3.0f; // 着地後に止まる時間

    private EnemyA enemyA;
    public ENEMY_A_STATE state => ENEMY_A_STATE.E_A_STATE_MOVE;
    public EnemyAStateMove(EnemyA e) => enemyA = e;

    private Rigidbody2D rigidbody2D; // 敵Aのrigidbody2D
    private SpriteRenderer spriteRenderer; // 敵AのspriteRenderer
    private CheckOnGround checkOnGround; // 地面との当たり判定をする
    private GameObject player; // プレイヤーオブジェクト

    private bool isRight = true; // 右を向いているならtrue
    private bool isJump = false; // ジャンプするならtrue
    private float moveSpeed = 0.2f; // 移動速度
    private float jumpForce = 3.0f; // ジャンプ力
    private float waitTimer = 0.0f; // 着地後に止まる時間を管理するタイマー

    public void Entry()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = enemyA.GetComponent<Rigidbody2D>();
        spriteRenderer = enemyA.GetComponent<SpriteRenderer>();
        checkOnGround = enemyA.GetComponent<CheckOnGround>();
    }

    public void Update()
    {
        // 地面に足がついていて、ジャンプしていない場合
        if (checkOnGround.onGround == true && isJump == false)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= WAIT_TIME)
            {
                Debug.Log("停止解除");
                isJump = true;
                waitTimer -= WAIT_TIME;
            }
        }
        else
        {
            Jump(); // ジャンプ
            Walk(); // 移動処理
        }
    }

    public void Exit()
    {

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
        rigidbody2D.linearVelocity = new Vector2(direction * moveSpeed, rigidbody2D.linearVelocity.y);

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

    private void Jump()
    {
        if (isJump == true)
        {
            isJump = false;
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
