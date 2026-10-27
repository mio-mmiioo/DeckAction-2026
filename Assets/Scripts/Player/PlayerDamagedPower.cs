using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDamagedPower : MonoBehaviour
{

    private CharaHp charaHp; // HPを管理するクラス
    private int attackedPower = 5; // 攻撃力

    void Start()
    {
        charaHp = GetComponent<CharaHp>();
    }

    //void Update()
    //{
    //    // 敵の攻撃力を取得する処理
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            Debug.Log("プレイヤーは敵から" + attackedPower + "の攻撃を受けた");
            charaHp.TakeDamage(attackedPower);
        }
    }
}
