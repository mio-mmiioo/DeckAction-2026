using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(speed, 0.0f); // 移動方向に力を加える
        // カメラに映らなくなった場合
        if (sr.isVisible == false)
        {
            Destroy(gameObject);
        }
    }
}
