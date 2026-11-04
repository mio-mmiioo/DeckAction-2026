using UnityEngine;

// プレイヤーの攻撃を有効にする
public class PlayerEnableAttack : MonoBehaviour
{
    [Tooltip("攻撃の当たり判定の範囲を指定してください")]
    [SerializeField] private Collider2D attackCollider;

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
        Invoke("SetOffEnabled", time); // 指定秒数後に攻撃判定をオフにする
    }

    /// <summary>
    /// 攻撃判定をオフに設定
    /// </summary>
    private void SetOffEnabled()
    {
        attackCollider.enabled = false;
    }
}
