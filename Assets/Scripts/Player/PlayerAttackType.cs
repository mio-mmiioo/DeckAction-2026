using UnityEngine;
using UnityEngine.InputSystem;

// 攻撃の種類と情報を管理するクラス
public class PlayerAttackType : MonoBehaviour
{
    [Tooltip("CardDataBaseを設定してください")]
    [SerializeField] private CardDataBase cardDataBase; // カードの情報

    [Tooltip("カードを使用した攻撃判定をするならtrueにしてください")]
    [SerializeField] private bool isUseCard = false;

    [Tooltip("物理攻撃のオブジェクトを設定してください")]
    [SerializeField] private GameObject physicalAttackObject; // 物理攻撃

    private PlayerAttack physicalAttack;

    private PlayerCombo playerCombo;

    private Stamina stamina;

    private PlayerEnableAttack playerEnableAttack;

    private int currentID = 2; // 現在のカードのID
    private int comboCount; // 現在のコンボ数
    private bool isAttack; // 

    void Start()
    {
        physicalAttack = physicalAttackObject.GetComponent<PlayerAttack>();
        playerCombo= GetComponent<PlayerCombo>();
        playerEnableAttack =GetComponent<PlayerEnableAttack>();
        stamina = GetComponent<Stamina>();
    }

    /// <summary>
    /// 使用したカードのIDを設定する
    /// </summary>
    public void SetCardID()
    {
        if (isUseCard == true)
        {
            
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


        (currentID,comboCount,isAttack)= playerCombo.ComboSet();

        if(isAttack)
        {
            SetAttackPower(); // 攻撃力を設定
            playerEnableAttack.Attack();
            stamina.UseStamina(currentID);
            isAttack= false; // 
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
    /// 使用されたカードによってダメージをセットする
    /// </summary>
    public void SetAttackPower()
    {
        int damage = cardDataBase.CardData[currentID].damage;
        // コンボの処理　攻撃を計算する処理



        // 最終的なダメージ

        physicalAttack.SetAttackPower(damage);
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
