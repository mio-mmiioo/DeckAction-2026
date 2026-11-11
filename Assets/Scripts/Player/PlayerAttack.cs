using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int attackPower; // 攻撃力
    
    /// <summary>
    /// 攻撃力をセットする
    /// </summary>
    /// <param name="power">攻撃力</param>
    public void SetAttackPower(int power)
    {
        attackPower = power;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            CharaHp charaHp = other.GetComponent<CharaHp>();
            charaHp.TakeDamage(attackPower);
        }
    }
}
