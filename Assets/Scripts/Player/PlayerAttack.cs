using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private AttackPower attackPower; // 攻撃力

    void Start()
    {
        attackPower = GetComponent<AttackPower>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            CharaHp charaHp = other.GetComponent<CharaHp>();
            charaHp.TakeDamage(attackPower.GetAttackPower());
        }
    }
}
