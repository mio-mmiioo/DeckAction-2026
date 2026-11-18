using UnityEngine;

public class Sword : MonoBehaviour
{
    private const float MOVE_SPEED = 3.0f;

    private Vector2 direction;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 剣を飛ばす
    /// </summary>
    /// <param name="targetPosition">飛ばす方向</param>
    public void LaunchSword(Vector3 targetPosition)
    {
        direction = (targetPosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 剣の向きを進行方向に合わせる
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rb.linearVelocity = direction * MOVE_SPEED;
    }
}
