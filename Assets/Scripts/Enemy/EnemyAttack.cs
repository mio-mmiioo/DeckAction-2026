using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Tooltip("攻撃力を設定してください")]
    [SerializeField] private int attackPower = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("プレイヤーに当たってはいる");
            CharaHp charaHp = other.GetComponent<CharaHp>();
            Debug.Log("プレイヤーは敵から" + attackPower + "の攻撃を受けた");
            charaHp.TakeDamage(attackPower);
        }
    }
}
