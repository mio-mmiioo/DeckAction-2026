using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] CharaHp charaHp; // HPを管理するクラス

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            charaHp.TakeDamage(5);
        }
    }
}
