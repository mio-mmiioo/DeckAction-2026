using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("攻撃力を設定してください")]
    [SerializeField] private int attackPower;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            CharaHp charaHp = other.GetComponent<CharaHp>();
            Debug.Log("敵は" + attackPower + "の攻撃を受けた");
            charaHp.TakeDamage(attackPower);
        }
    }
}
