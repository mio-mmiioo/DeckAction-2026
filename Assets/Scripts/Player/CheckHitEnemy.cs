using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 敵との衝突を確認し、衝突の場合、敵との当たり判定を無効にする
/// </summary>
public class CheckHitEnemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CharaHp charaHp; // 無敵時間を取得するために使用
    private float invincibleTime; // 無敵時間
    private float invincibleTimer; // 無敵時間のタイマー
    private const float BLINKING_INTERVAL = 0.3f; // 点滅する時間間隔
    private float blinkingTimer; // 点滅する時間のタイマー
    private bool isInvincible; // 無敵時間ならtrue
    private int playerLayer; // Playerのレイヤー番号
    private int enemyLayer; // Enemyのレイヤー番号

    void Start()
    {
        // レイヤー番号のセット
        playerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");

        // 無敵時間 当たり判定無効時間の設定
        charaHp = GetComponent<CharaHp>();
        invincibleTime = charaHp.invincibleTime;
        invincibleTimer = invincibleTime;
        isInvincible = false;
        blinkingTimer = 0.0f;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isInvincible == true)
        {
            invincibleTimer -= Time.deltaTime;
            blinkingTimer -= Time.deltaTime;

            // 無敵時間中は点滅
            if (blinkingTimer <= 0.0f)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                blinkingTimer += BLINKING_INTERVAL;
            }

            // 無敵時間終了の場合
            if (invincibleTimer < 0.0f)
            {
                Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false); // 一定時間経過後は判定を有効にする
                spriteRenderer.enabled = true;
                isInvincible= false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突した相手のレイヤーがEnemyの場合
        if (collision.gameObject.layer == enemyLayer && isInvincible == false)
        {
            StartCoroutine(IgnoreCollision());
            invincibleTimer = invincibleTime;
            blinkingTimer = BLINKING_INTERVAL;
            isInvincible = true;
        }
    }

    /// <summary>
    /// 一定時間当たり判定を無効にする処理
    /// </summary>
    /// <returns></returns>
    private IEnumerator IgnoreCollision()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer); // プレイヤーと敵レイヤーの判定を無効にする

        yield return new WaitForSeconds(invincibleTime); // 無敵時間待機する
    }
}
