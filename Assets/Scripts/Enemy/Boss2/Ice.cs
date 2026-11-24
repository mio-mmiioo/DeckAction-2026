using System.Collections;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [Tooltip("成長速度")]
    [SerializeField] private float growInterval = 0.5f;

    [SerializeField]
    private float[] growScales =
    {
        0.1f, 0.2f, 0.4f
    };

    [Tooltip("落下速度")]
    [SerializeField] private float fallSpeed = 5.0f;

    [Tooltip("成長後の待ち時間")]
    [SerializeField] private float waitFallTime = 0.7f;

    [Tooltip("攻撃力")]
    [SerializeField] private int attackPower = 10;

    private const int MAX_FHASE = 3; // 成長の段階の最大数

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    private bool isFalling = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // 落下させない設定
    }

    private void Start()
    {
        StartCoroutine(GrowAndFall());
    }

    private IEnumerator GrowAndFall()
    {
        // 指定回数、成長させる
        for (int count = 0; count < MAX_FHASE; count++)
        {
            float scale = growScales[count];
            transform.localScale = new Vector3(scale, scale, 1.0f);
            yield return new WaitForSeconds(growInterval);
        }

        // 落下前に揺らしたいなどの場合はここに
        yield return new WaitForSeconds(waitFallTime); // 落下前に一時停止

        Fall(); // 落下させる
    }

    /// <summary>
    /// 落下処理
    /// </summary>
    private void Fall()
    {
        isFalling = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0.0f;
        rb.linearVelocity = Vector2.down * fallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isFalling ==false)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            CharaHp charaHp = collision.gameObject.GetComponent<CharaHp>();
            charaHp.TakeDamage(attackPower);
        }

        Destroy(gameObject); // 何かに衝突した場合壊れる
    }
}
