using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyDamagedPower : MonoBehaviour
{
    [SerializeField] private CharaHp charaHp; // HPを管理するクラス
    [SerializeField] private CardDataBase cardDataBase; // カードの情報
    [SerializeField] private int cardID = 0; // カードのID
    [SerializeField] private int attackPower = 5; // 攻撃力

    // 攻撃力をセットする
    // 移動させる
    void Update()
    {
        // プレイヤーの攻撃力をセットする
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            cardID = 1;
        }
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            cardID = 2;
        }
        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            cardID = 3;
        }
        attackPower = cardDataBase.CardData[cardID].damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(attackPower);
        charaHp.TakeDamage(attackPower);
    }
}
