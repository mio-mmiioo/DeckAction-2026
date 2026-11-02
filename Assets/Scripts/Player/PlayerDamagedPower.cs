using UnityEngine;

public class PlayerDamagedPower : MonoBehaviour
{
    [Tooltip("プレイヤーのCharaHpを設定してください")]
    [SerializeField] private CharaHp charaHp;
    
    private int attackedPower = 5; // 攻撃力

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
