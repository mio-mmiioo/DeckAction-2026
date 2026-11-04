using UnityEngine;

public class CharaColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Color normalColor = Color.white; // 通常時の色
    private Color chargeColor = Color.yellow; // 攻撃前のための色
    private Color damageColor = Color.red; // 攻撃されたときの色

    private const float BLINK_TIME = 1.0f; // 点滅時の切り替えの時間
    private float blinkTimer = 0.0f; // 点滅時のタイマー
    private float invincibleTimer = 0.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (invincibleTimer > 0.0f)
        {
            invincibleTimer -= Time.deltaTime;
            blinkTimer -= Time.deltaTime;
            if (blinkTimer >= 0.0f)
            {
                blinkTimer += BLINK_TIME;
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }
        }
    }

    /// <summary>
    /// 「攻撃のため」の時に徐々に色を変化させる処理
    /// </summary>
    /// <param name="rate">変化させる割合</param>
    public void ChargeAttack(float rate)
    {
        if (spriteRenderer.color != damageColor)
        {
            spriteRenderer.color = Color.Lerp(normalColor, chargeColor, rate); // 変化前, 変化後, 割合
        }
    }

    /// <summary>
    /// 攻撃されたときの色
    /// </summary>
    public void Attacked()
    {
        spriteRenderer.color = damageColor;
    }

    /// <summary>
    /// 攻撃されたときに点滅する処理の開始
    /// </summary>
    /// <param name="invincibleTime">点滅時間( 無敵時間 )</param>
    public void StartDamageBlink(float invincibleTime)
    {
        invincibleTimer = invincibleTime;
    }

    // 通常の色に戻す
    public void ResetColor()
    {
        spriteRenderer.color = normalColor;
    }
}
