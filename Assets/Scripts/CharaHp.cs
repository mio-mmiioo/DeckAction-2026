using UnityEngine;

public class CharaHp : MonoBehaviour
{
    [SerializeField] private int maxHp = 100; // 最大の体力
    [SerializeField] private int currentHp; // 現在の体力

    void Start()
    {
        currentHp = maxHp;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp); // 体力の最小と最大の値を決める
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
        currentHp -= damage;

        // 体力がなくなったら消す
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
