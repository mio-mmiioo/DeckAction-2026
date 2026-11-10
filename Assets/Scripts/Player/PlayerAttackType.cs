using UnityEngine;
using UnityEngine.InputSystem;

// 攻撃の種類と情報を管理するクラス
public class PlayerAttackType : MonoBehaviour
{
    [Tooltip("CardDataBaseを設定してください")]
    [SerializeField] private CardDataBase cardDataBase; // カードの情報

    [Tooltip("物理攻撃のオブジェクトを設定してください")]
    [SerializeField] private GameObject physicalAttackObject; // 物理攻撃

    [Tooltip("魔法攻撃のオブジェクトを設定してください")]
    [SerializeField] private GameObject magicAttackObject; // 魔法攻撃

    private PlayerCombo playerCombo;

    private Stamina stamina;

    private int currentID = 2; // 現在のカードのID
    private int comboCount; // 現在のコンボ数
    private bool isAttack; // 

    void Start()
    {
        playerCombo = GetComponent<PlayerCombo>();
        stamina = GetComponent<Stamina>();
    }

    /// <summary>
    /// 使用したカードのIDを設定する
    /// </summary>
    public void SetCardID()
    {
        (currentID,comboCount,isAttack)= playerCombo.ComboSet();

        if(isAttack)
        {
            SetAttackPower(); // 攻撃力を設定

            switch (currentID)
            {
                case 1:
                    physicalAttackObject.GetComponent<PlayerEnableAttack>().Attack();
                    break;

                case 2:
                    magicAttackObject.GetComponent<PlayerEnableAttack>().Attack();
                    break;
            }
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
        switch (currentID)
        {
            case 1:
                physicalAttackObject.GetComponent<PlayerAttack>().SetAttackPower(damage);
                break;

            case 2:
                magicAttackObject.GetComponent<PlayerAttack>().SetAttackPower(damage);
                break;
        }
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
