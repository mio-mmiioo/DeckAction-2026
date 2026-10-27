using UnityEngine;
using UnityEngine.InputSystem;

// 攻撃の種類と情報を管理するクラス
public class PlayerAttackType : MonoBehaviour
{
    [SerializeField] private CardDataBase cardDataBase; // カードの情報
    [SerializeField] private int cardID; // カードのID
    [SerializeField] private CardManager cardManager;
    private PlayerAttack playerAttack;
    private int currentID = 0;
    private int prevID;

    void Start()
    {
        prevID = currentID;
        playerAttack = GetComponent<PlayerAttack>();
    }

    /// <summary>
    /// 使用したカードのIDを設定する
    /// </summary>
    public void SetCardID()
    {
        currentID = cardManager.GetUseCard();
        if (currentID == 0 && currentID == prevID)
        {
            prevID = currentID;
            return;
        }
        cardID = currentID;
        prevID = currentID;
        playerAttack.Attack();

        //// プレイヤーの攻撃力をセットする
        //if (Keyboard.current.zKey.wasPressedThisFrame)
        //{
        //    cardID = 1;
        //}
        //if (Keyboard.current.xKey.wasPressedThisFrame)
        //{
        //    cardID = 2;
        //}
        //if (Keyboard.current.cKey.wasPressedThisFrame)
        //{
        //    cardID = 4;
        //}
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
        int ret = cardDataBase.CardData[cardID].damage;
        // コンボの処理



        // 最終的なダメージ
        
        
        
        return ret;
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
