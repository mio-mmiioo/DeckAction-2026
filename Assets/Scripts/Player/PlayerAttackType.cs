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

    private bool isAttack; // 攻撃する場合true

    void Start()
    {
        magicPosition = GetComponent<SetMagicAttackPosition>();
    }

    /// <summary>
    /// 使用したカードのIDを設定する
    /// </summary>
    public void SetCardID(int id,int power)
    {
        if(isAttack)
        {
            switch (id)
            {
                case 1:;
                    physicalAttackObject.GetComponent<PlayerEnableAttack>().Attack();
                    physicalAttackObject.GetComponent<AttackPower>().SetAttackPower(power);
                    break;

                case 2:
                    // 魔法攻撃を生成する
                    GameObject magic = Instantiate(magicAttackObject, magicPosition.GetCreatePosition().position, Quaternion.identity);
                    magic.GetComponent<AttackPower>().SetAttackPower(power);
                    break;
            }
            isAttack= false;
        }
        
    }
}
