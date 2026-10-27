using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Collider2D attackCollider; // 攻撃範囲
    [SerializeField] private float animationLength = 0.3f; // アニメーションの長さ
    [SerializeField] private Stamina stamina; // スタミナ
    [SerializeField] private PlayerAttackType playerAttackType; // 攻撃の情報

    void Start()
    {
        SetOffEnabled();
    }

    /// <summary>
    /// 攻撃の処理を行う
    /// </summary>
    public void Attack()
    {
        attackCollider.enabled = true; // 攻撃範囲を有効にする
        Invoke("SetOffEnabled", animationLength); // 指定秒数後に攻撃判定をオフにする
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
