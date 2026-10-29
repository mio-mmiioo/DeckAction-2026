using UnityEngine;

public class EnemyAStateWalk : IEnemyAState
{
    EnemyA enemyA;
    public ENEMY_A_STATE state => ENEMY_A_STATE.E_A_STATE_WALK;
    public EnemyAStateWalk(EnemyA e) => enemyA = e;

    private Rigidbody2D rigidbody2D; // 敵Aのrigidbody2D
    private SpriteRenderer spriteRenderer; // 敵AのspriteRenderer
    private GameObject player;

    private bool isRight = true; // 右を向いているならtrue
    private float moveSpeed = 0.2f;


    public void Entry()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody2D = enemyA.GetComponent<Rigidbody2D>();
        spriteRenderer = enemyA.GetComponent<SpriteRenderer>();
    }

    public void Update()
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

    public void Exit()
    {

    }
}
