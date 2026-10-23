using UnityEngine;

public class CharaCheckDamage : MonoBehaviour
{
    [SerializeField] private CharaHp charaHp; // HPを管理するクラス
    [SerializeField] private int attackPower = 5; // 攻撃力
    [SerializeField] private string AttackTag; // 攻撃のタグ名

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(AttackTag))
        {
            Debug.Log(attackPower);
            charaHp.TakeDamage(attackPower);
        }
    }
}
