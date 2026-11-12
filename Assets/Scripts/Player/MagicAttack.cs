using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    [Tooltip("魔法攻撃の移動速度を設定してください")]
    [SerializeField] float speed = 3.0f;

    private GameObject player;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private float direction; // 攻撃を飛ばす方向
    private int attackPower = 5; // 攻撃力

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        player = GameObject.Find("Player");
        if (player.GetComponent<Transform>().localScale.x > 0)
        {
            direction = 1.0f;
        }
        else
        {
            direction = -1.0f;
        }
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(direction * speed, 0.0f); // 移動方向に力を加える
        // カメラに映らなくなった場合
        if (sr.isVisible == false)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 攻撃力をセットする
    /// </summary>
    /// <param name="power">攻撃力</param>
    public void SetAttackPower(int power)
    {
        Debug.Log("魔法攻撃力が" + power + "になった");
        attackPower = power;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CharaHp charaHp = other.gameObject.GetComponent<CharaHp>();
            charaHp.TakeDamage(attackPower);
            Debug.Log("敵に" + attackPower + "のダメージを与えた");
            Destroy(gameObject);
        }
    }
}
