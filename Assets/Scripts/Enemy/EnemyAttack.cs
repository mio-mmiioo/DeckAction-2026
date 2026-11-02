using UnityEngine;

/// <summary>
/// 本体の当たり判定をする子オブジェクトのコンポーネントとして使用する
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    [Tooltip("攻撃力を設定してください")]
    [SerializeField] private int attackPower = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharaHp charaHp = other.GetComponent<CharaHp>();
            Debug.Log("プレイヤーは" + attackPower + "の攻撃を受けた");
            charaHp.TakeDamage(attackPower);
        }
    }
}
