using UnityEngine;

public class CharaHp : MonoBehaviour
{
    [Tooltip("最大の体力を設定してください")]
    [SerializeField] private int maxHP = 100;

    [Tooltip("現在の体力")]
    [SerializeField] private int currentHP; // 現在の体力

    void Start()
    {
        currentHP = maxHP;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // 体力の最小と最大の値を決める
    }

    /// <summary>
    /// 体力を減らす処理
    /// </summary>
    /// <param name="damage">攻撃力( a > 0 )</param>
    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            return;
        }
        currentHP -= damage;

        // 体力がなくなったら消す
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 体力を加算する
    /// </summary>
    /// <param name="hp">加算される体力</param>
    public void AddHP(int hp)
    {
        currentHP += hp;
    }
}
