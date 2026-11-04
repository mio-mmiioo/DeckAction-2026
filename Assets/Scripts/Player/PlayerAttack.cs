using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int attackPower;

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
            Debug.Log("敵は" + attackPower + "の攻撃を受けた");
            charaHp.TakeDamage(attackPower);
        }
    }
}
