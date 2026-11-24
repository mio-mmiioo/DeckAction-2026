using UnityEngine;

/// <summary>
/// プレイヤーがカードを使った時の処理を管理するクラス
/// 攻撃力や、スタミナ、被ダメージ増加などの効果をここで管理する
/// </summary>
public class PlayerUseCard : MonoBehaviour
{
    [SerializeField] CardManager cardManager;//カードマネージャー

    [SerializeField] CardDataBase cardDataBase;//カードのデータ

    [SerializeField] CardAbilityTable cardAbilityTable;//カードの追加効果のデーター

    [HideInInspector] public Player player;//プレイヤー

    [HideInInspector] public Stamina stamina;//スタミナ

    [HideInInspector] public CharaHp charaHp;//HP

    private PlayerAttackType playerAttackType;
    private ComboCount comboCount;
    private PlayerCombo playerCombo;
    private AttackTarget attackTarget;
   
    private int attack;

    //追加効果で設定される各種値
    [HideInInspector]public int nextAttack;
    [HideInInspector] public int nextStamina;
    [HideInInspector] public bool plusAttack;

    [HideInInspector]public bool prevMaxCombo;

    public int currentCombo;

    [SerializeField]
    private CardParameterData cardParameterData;

    [SerializeField]
    private int[] comboPower;

    [HideInInspector] public bool isNextMagicPower;
    [HideInInspector] public bool isMagicPower;

    [HideInInspector] public int turn;

    [HideInInspector] public float limitTime;

    private CharaHp targetHp;//ターゲットのHP

    void Start()
    {
        playerAttackType = GetComponent<PlayerAttackType>();
        comboCount = GetComponent<ComboCount>();
        playerCombo = GetComponent<PlayerCombo>();
        charaHp = GetComponent<CharaHp>();
        attackTarget = GetComponent<AttackTarget>();

        currentCombo = 0;
        comboPower = new int[4] { 1, 2, 3, 4 };
        nextStamina = 0;
        nextAttack = 0;
        limitTime = 1.0f;
    }

    private void Update()
    {
        turn = cardParameterData.cardType;
        limitTime -= Time.deltaTime;
    }


    /// <summary>
    /// カードを使った時の処理をここで一度にやる
    /// </summary>
    public void UseCard()
    {
        // ターゲットがいないなら、手札に戻す
        if(!attackTarget.GetTargetHP())
        {
            cardManager.UseCardReturn();
        }
        else if (limitTime < 0)
        {
            cardParameterData = cardManager.GetUseCard();//使用したカードのパラメーターを取得

            if (cardParameterData.cardType != 0&&attackTarget.GetTargetHP())
            {
                //コンボの判定
                CardAbility cardAbility = cardAbilityTable.CardAbilityList[cardParameterData.cardRarity].CardAbilities[cardParameterData.cardAbility];//カードの効果を発動
                cardAbility.Execute(this, cardManager);
                stamina.UseStamina(cardDataBase.CardData[cardParameterData.cardType].stamina - nextStamina);//ｽﾀﾐﾅを消費        

                if(attackTarget.GetTargetHP())
                attackTarget.GetTargetHP().TakeDamage(CalculationPower());

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
