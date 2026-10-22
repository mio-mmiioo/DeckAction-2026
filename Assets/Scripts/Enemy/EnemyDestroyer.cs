using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            Destroy(gameObject); // 敵を消す
        }

    }
}
