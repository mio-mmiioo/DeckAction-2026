using UnityEngine;

// プレイヤーの攻撃を有効にする
public class PlayerEnableAttack : MonoBehaviour
{
    [Tooltip("攻撃の当たり判定の範囲を指定してください")]
    [SerializeField] private Collider2D attackCollider;

    [Tooltip("攻撃が有効時の画像を設定してください")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Tooltip("攻撃判定が有効な時間")]
    [SerializeField] private float time = 0.3f;

    void Start()
    {
        SetOffEnabled();
    }

    /// <summary>
    /// 攻撃可能にする 一定時間経過後不可になる
    /// </summary>
    public void Attack()
    {
        attackCollider.enabled = true; // 攻撃範囲を有効にする
        spriteRenderer.enabled = true; // 描画を有効にする
        Invoke("SetOffEnabled", time); // オフにする
    }

    /// <summary>
    /// 判定をオフに設定する
    /// </summary>
    private void SetOffEnabled()
    {
        attackCollider.enabled = false; // 攻撃範囲
        spriteRenderer.enabled = false; // 描画
    }
}
