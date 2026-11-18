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

    [SerializeField] PlayerAttack playerAttack;


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


    private CardParameterData cardParameterData;

    [SerializeField]
    private int[] comboPower;


    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        playerAttackType = GetComponent<PlayerAttackType>();
        comboCount = GetComponent<ComboCount>();
        playerCombo = GetComponent<PlayerCombo>();


        comboPower = new int[4] { 1, 2, 3, 4 };
        nextStamina = 0;
        nextAttack = 0;
    }

    private void Update()
    {
        
    }


    /// <summary>
    /// カードを使った時の処理をここで一度にやる
    /// </summary>
    public void UseCard()
    {
        cardParameterData= cardManager.GetUseCard();//使用したカードのパラメーターを取得
        if (cardParameterData.cardType != 0)
        {
            CardAbility cardAbility = cardAbilityTable.CardAbilityList_1[0];//カードの効果を発動
            cardAbility.Execute(this, cardManager);
            stamina.UseStamina(cardDataBase.CardData[cardParameterData.cardType].stamina - nextStamina);//ｽﾀﾐﾅを消費        
            playerAttackType.SetCardID(cardParameterData.cardType, CalculationPower());//攻撃の種類を設定
            nextAttack = 0;
            nextStamina = 0;
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

        return power;
    }


    


}
