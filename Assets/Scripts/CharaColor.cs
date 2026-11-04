using UnityEngine;

public class CharaColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Color normalColor = Color.white; // 通常時の色
    private Color chargeColor = Color.yellow; // 攻撃前のための色
    private Color damageColor = Color.red; // 攻撃されたときの色

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    // 通常の色に戻す
    public void ResetColor()
    {
        spriteRenderer.color = normalColor;
    }
}
