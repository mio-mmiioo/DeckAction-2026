using UnityEngine;

/// <summary>
/// プレイヤーがカードを使った時の処理を管理するクラス
/// 攻撃力や、スタミナ、被ダメージ増加などの効果をここで管理する
/// </summary>
public class PlayerUseCard : MonoBehaviour
{
    [SerializeField] CardManager cardManager;

    [SerializeField] CardAbilityTable cardAbilityTable;

    [SerializeField] CardDataBase cardDataBase;


    public Player player;

    public Stamina stamina;

    private PlayerAttackType playerAttackType;
    private ComboCount comboCount;
    private PlayerCombo playerCombo;

   
    private int attack;

    [SerializeField]
    public int nextAttack;
    public int nextStamina;

    private bool prevMaxCombo;

    public int currentCombo;

    [SerializeField]
    private CardParameterData cardParameterData;

    [SerializeField]
    private int[] comboPower;

    public int texn;

    public float limitTime;

    void Start()
    {
        playerAttackType = GetComponent<PlayerAttackType>();
        comboCount = GetComponent<ComboCount>();
        playerCombo = GetComponent<PlayerCombo>();

        currentCombo = 0;
        comboPower = new int[4] { 1, 2, 3, 4 };
        nextStamina = 0;
        nextAttack = 0;
        limitTime = 1.0f;
    }

    private void Update()
    {
        texn = cardParameterData.cardType;
        limitTime -= Time.deltaTime;
    }


    /// <summary>
    /// カードを使った時の処理をここで一度にやる
    /// </summary>
    public void UseCard()
    {
        if (limitTime < 0)
        {
            cardParameterData = cardManager.GetUseCard();//使用したカードのパラメーターを取得

            if (cardParameterData.cardType != 0)
            {
                CardAbility cardAbility = cardAbilityTable.CardAbilityList_1[0];//カードの効果を発動
                cardAbility.Execute(this, cardManager);
                stamina.UseStamina(cardDataBase.CardData[cardParameterData.cardType].stamina - nextStamina);//ｽﾀﾐﾅを消費        
                playerAttackType.SetCardID(cardParameterData.cardType, CalculationPower());//攻撃の種類を設定

                comboCount.SetComboCount(currentCombo);

                limitTime = 1.0f;
            }
        }
    }

    /// <summary>
    /// 攻撃力の計算
    /// </summary>
    /// <returns></returns>
    private int CalculationPower()
    {
        int power = 0;
        int cardPower = cardDataBase.CardData[cardParameterData.cardType].damage;

        power = (cardPower+nextAttack)*comboPower[currentCombo];

        //nextAttack = 0;
        //nextStamina = 0;

        return power;
    }


    


}
