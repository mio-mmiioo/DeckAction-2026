using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyDamagedPower : MonoBehaviour
{
    [Tooltip("プレイヤーの攻撃の種類 PlayerAttackTypeを設定してください")]
    [SerializeField] private PlayerAttackType playerAttackType; // プレイヤーの攻撃
    private CharaHp charaHp; // HPを管理するクラス
    private int attackPower = 5; // 攻撃力

    void Start()
    {
        charaHp = GetComponent<CharaHp>();
    }
    // 攻撃力をセットする
    // 移動させる
    void Update()
    {
        attackPower = playerAttackType.GetAttackPower();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        charaHp.TakeDamage(attackPower);
    }
}
