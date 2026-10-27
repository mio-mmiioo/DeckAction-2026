using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyDamagedPower : MonoBehaviour
{
    [SerializeField] private CharaHp charaHp; // HPを管理するクラス
    [SerializeField] private int attackPower = 5; // 攻撃力
    [SerializeField] private PlayerAttackType playerAttackType; // プレイヤーの攻撃

    // 攻撃力をセットする
    // 移動させる
    void Update()
    {
        attackPower = playerAttackType.GetAttackPower();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(attackPower);
        charaHp.TakeDamage(attackPower);
    }
}
