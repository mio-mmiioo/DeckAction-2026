using UnityEngine;
using UnityEngine.InputSystem;

// 攻撃の種類と情報を管理するクラス
public class PlayerAttackType : MonoBehaviour
{
    [SerializeField] private CardDataBase cardDataBase; // カードの情報
    [SerializeField] private int cardID; // カードのID

    public void SetCardID()
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
    }

    /// <summary>
    /// 使用されたカードのIDを取得する
    /// </summary>
    /// <returns>カードのID</returns>
    public int GetCardID()
    {
        return cardID;
    }

    /// <summary>
    /// 使用されたカードのダメージを取得する
    /// </summary>
    /// <returns>ダメージ</returns>
    public int GetAttackPower()
    {
        return cardDataBase.CardData[cardID].damage;
    }

    /// <summary>
    /// 使用されたカードの消費スタミナを取得する
    /// </summary>
    /// <returns>消費スタミナ</returns>
    public int GetUseStamina()
    {
        return cardDataBase.CardData[cardID].stamina;
    }
}
