using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDamagedPower : MonoBehaviour
{
    [SerializeField] private CharaHp charaHp; // HPを管理するクラス
    [SerializeField] private int attackPower = 5; // 攻撃力

    //void Update()
    //{
    //    // 敵の攻撃力を取得する処理
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(attackPower);
        charaHp.TakeDamage(attackPower);
    }
}
