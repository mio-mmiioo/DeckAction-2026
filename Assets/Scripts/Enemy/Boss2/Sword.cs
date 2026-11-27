using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f; // 剣の移動速度

    private Vector2 direction; // 剣を飛ばす方向
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        // カメラに映らなくなった場合
        if (sr.isVisible == false)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 剣を飛ばす
    /// </summary>
    /// <param name="targetPosition">飛ばす方向</param>
    public void LaunchSword(Vector3 targetPosition)
    {
        direction = (targetPosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f; // 剣の向きを進行方向に合わせる
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rb.linearVelocity = direction * moveSpeed;
    }
}
