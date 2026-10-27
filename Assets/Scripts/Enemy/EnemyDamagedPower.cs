using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyDamagedPower : MonoBehaviour
{
    private PlayerAttackType playerAttackType; // プレイヤーの攻撃
    private CharaHp charaHp; // HPを管理するクラス
    private int attackPower = 5; // 攻撃力

    void Start()
    {
        charaHp = GetComponent<CharaHp>();
        playerAttackType = GetComponent<PlayerAttackType>();
    }
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
