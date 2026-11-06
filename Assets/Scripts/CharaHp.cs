using UnityEngine;

public class CharaHp : MonoBehaviour
{
    [Tooltip("最大の体力を設定してください")]
    [SerializeField] private int maxHP = 100;

    [Tooltip("現在の体力")]
    [SerializeField] private int currentHP;

    [Tooltip("無敵時間を設定してください")]
    [SerializeField] public float invincibleTime = 4.0f;

    [Tooltip("無敵時間のタイマー")]
    [SerializeField] private float invincibleTimer;

    private CharaColor charaColor;

    void Start()
    {
        currentHP = maxHP;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // 体力の最小と最大の値を決める
        invincibleTimer = 0.0f;

        charaColor = GetComponent<CharaColor>();
    }

    void Update()
    {
        if (invincibleTimer > 0.0f)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0.0f)
            {
                charaColor.ResetColor();
            }
        }
    }

    /// <summary>
    /// 体力を減らす処理
    /// </summary>
    /// <param name="damage">攻撃力( a > 0 )</param>
    public void TakeDamage(int damage)
    {
        // ダメージがマイナスor無敵時間の場合はHPを減らさない
        if (damage <= 0 || invincibleTimer > 0.0f)
        {
            return;
        }

        // 攻撃された
        currentHP -= damage; // HPを減らす
        invincibleTimer = invincibleTime; // 無敵時間を設定
        charaColor.StartDamageBlink(invincibleTime); // 点滅処理の開始
        charaColor.Attacked(); // 色を変化させる

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

    /// <summary>
    /// 現在の体力を返す
    /// </summary>
    /// <returns></returns>
    public int GetHP()
    {
        return currentHP;
    }

    /// <summary>
    /// 最大体力を返す
    /// </summary>
    /// <returns></returns>
    public int GetMaxHP()
    {
        return maxHP;
    }
}
