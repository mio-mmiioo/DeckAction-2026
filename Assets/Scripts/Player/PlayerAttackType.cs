using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

// 攻撃の種類と情報を管理するクラス
public class PlayerAttackType : MonoBehaviour
{
    [Tooltip("CardDataBaseを設定してください")]
    [SerializeField] private CardDataBase cardDataBase; // カードの情報

    [Tooltip("物理攻撃のオブジェクトを設定してください")]
    [SerializeField] private GameObject physicalAttackObject; // 物理攻撃

    [Tooltip("魔法攻撃のオブジェクトを設定してください")]
    [SerializeField] private GameObject magicAttackObject; // 魔法攻撃

    private SetMagicAttackPosition magicPosition; // 魔法攻撃を生成する位置

    private PlayerCombo playerCombo;

    private ComboCount comboCountText;

    private Stamina stamina;

    private int currentID = 2; // 現在のカードのID
    private int comboCount; // 現在のコンボ数
    private bool isAttack; // 

    void Start()
    {
        //transform = GetComponent<Transform>();
        playerCombo = GetComponent<PlayerCombo>();
        stamina = GetComponent<Stamina>();
        comboCountText=GetComponent<ComboCount>();
        magicPosition = GetComponent<SetMagicAttackPosition>();
    }

    /// <summary>
    /// 使用したカードのIDを設定する
    /// </summary>
    public void SetCardID()
    {
        (currentID,comboCount,isAttack)= playerCombo.ComboGet();

        if(isAttack)
        {
            switch (currentID)
            {
                case 1:
                    physicalAttackObject.GetComponent<PlayerAttack>().SetAttackPower(SetAttackPower());
                    physicalAttackObject.GetComponent<PlayerEnableAttack>().Attack();
                    break;

                case 2:
                    // 魔法攻撃を生成する
                    GameObject magic = Instantiate(magicAttackObject, magicPosition.GetCreatePosition().position, Quaternion.identity);
                    magic.GetComponent<MagicAttack>().SetAttackPower(SetAttackPower());
                    break;
            }
            stamina.UseStamina(currentID);
            isAttack= false; // 
            comboCountText.SetComboCount(comboCount);
        }

        if(comboCount==0)
        {
            comboCountText.SetComboCount(comboCount);
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
    public int SetAttackPower()
    {
        int damage = cardDataBase.CardData[currentID].damage;
        
        // コンボの処理　攻撃を計算する処理

        return damage;
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
