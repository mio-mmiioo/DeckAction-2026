using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("攻撃の当たり判定の範囲を指定してください")]
    [SerializeField] private Collider2D attackCollider;

    [Tooltip("攻撃判定が有効な時間")]
    [SerializeField] private float time = 0.3f;

    private Stamina stamina; // スタミナ
    private PlayerAttackType playerAttackType; // 攻撃の情報

    void Start()
    {
        stamina = GetComponent<Stamina>();
        playerAttackType = GetComponent<PlayerAttackType>();
        SetOffEnabled();
    }

    /// <summary>
    /// 攻撃の処理を行う
    /// </summary>
    public void Attack()
    {
        attackCollider.enabled = true; // 攻撃範囲を有効にする
        Invoke("SetOffEnabled", time); // 指定秒数後に攻撃判定をオフにする
        stamina.UseStamina(playerAttackType.GetUseStamina()); // スタミナを消費
    }

    /// <summary>
    /// 攻撃判定をオフに設定
    /// </summary>
    private void SetOffEnabled()
    {
        attackCollider.enabled = false;
    }
}
