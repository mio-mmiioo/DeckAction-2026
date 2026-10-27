using UnityEngine;
using UnityEngine.InputSystem;

// 攻撃の種類と情報を管理するクラス
public class PlayerAttackType : MonoBehaviour
{
    [Tooltip("CardDataBaseを設定してください")]
    [SerializeField] private CardDataBase cardDataBase; // カードの情報

    //[Tooltip("CardManagerを設定して下い")]
    //[SerializeField] private CardManager cardManager;

    [Tooltip("カードを使用した攻撃判定をするならtrueにしてください")]
    [SerializeField] private bool isUseCard = false;

    private PlayerAttack playerAttack; // プレイヤーの攻撃処理
    private int currentID = 2; // 現在のカードのID
    private int prevID; // 前回のカードのID

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
        if (isUseCard == true)
        {
            //currentID = cardManager.GetUseCard();
            //if (currentID != 0 && currentID != prevID)
            //{
            //    playerAttack.Attack();
            //}
            //prevID = currentID;
        }
        else
        {
            // プレイヤーの攻撃力をセットする
            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                currentID = 1;
            }
            if (Keyboard.current.xKey.wasPressedThisFrame)
            {
                currentID = 2;
            }
            if (Keyboard.current.cKey.wasPressedThisFrame)
            {
                currentID = 4;
            }
        }
    }

    /// <summary>
    /// 使用されたカードのIDを取得する
    /// </summary>
    /// <returns>カードのID</returns>
    public int GetCardID()
    {
        return currentID;
    }

    /// <summary>
    /// 使用されたカードのダメージを取得する
    /// </summary>
    /// <returns>ダメージ</returns>
    public int GetAttackPower()
    {
        int ret = cardDataBase.CardData[currentID].damage;
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
        return cardDataBase.CardData[currentID].stamina;
    }
}
