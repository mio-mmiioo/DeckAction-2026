using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    [Tooltip("魔法攻撃の移動速度を設定してください")]
    [SerializeField] float speed = 3.0f;

    private GameObject player;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private AttackPower attackPower;

    private float direction; // 攻撃を飛ばす方向

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        attackPower = GetComponent<AttackPower>();

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CharaHp charaHp = other.gameObject.GetComponent<CharaHp>();
            charaHp.TakeDamage(attackPower.GetAttackPower());
            Destroy(gameObject);
        }
    }
}
