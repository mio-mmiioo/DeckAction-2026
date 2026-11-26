using UnityEngine;

/// <summary>
/// プレイヤーがカードを使った時の処理を管理するクラス
/// 攻撃力や、スタミナ、被ダメージ増加などの効果をここで管理する
/// </summary>
public class PlayerUseCard : MonoBehaviour
{
    [Tooltip("カードマネジャー")]
    [SerializeField] CardManager cardManager;// カードマネージャー

    [Tooltip("カードのデータベース")]
    [SerializeField] CardDataBase cardDataBase;// カードのデータ

    [Tooltip("追加効果のデータベース")]
    [SerializeField] CardAbilityTable cardAbilityTable;// カードの追加効果のデーター

    [HideInInspector] public Player player;// プレイヤー

    [HideInInspector] public Stamina stamina;// スタミナ

    [HideInInspector] public CharaHp charaHp;// HP

    // 各種プレイヤー攻撃にしようするスクリプト
    private PlayerAttackType playerAttackType;
    private ComboCount comboCount;
    private PlayerCombo playerCombo;
    private AttackTarget attackTarget;
    private CharaSetAttackTurn charaSetAttackTurn;


    private int attack;

    //追加効果で設定される各種値
    [HideInInspector]public int nextAttack;
    [HideInInspector] public int nextStamina;
    [HideInInspector] public bool plusAttack;
    [HideInInspector] public bool isNextMagicPower;
    [HideInInspector] public bool isMagicPower;
    [HideInInspector]public bool prevMaxCombo;// 前回マックスコンボならtrue

    public int currentCombo;// 現在のコンボ数

    private CardParameterData cardParameterData;// カードごとのパラメータ

    [SerializeField]
    private float[] comboPower = { 1, 2.5f, 4, 5.5f };// コンボごとにかかる倍率

    [HideInInspector] public float limitTime; //攻撃の間の間隔

    private CharaHp targetHp;// ターゲットのHP

    void Start()
    {
        playerAttackType = GetComponent<PlayerAttackType>();
        comboCount = GetComponent<ComboCount>();
        playerCombo = GetComponent<PlayerCombo>();
        charaHp = GetComponent<CharaHp>();
        attackTarget = GetComponent<AttackTarget>();
        charaSetAttackTurn = GetComponent<CharaSetAttackTurn>();

        currentCombo = 0;
        nextStamina = 0;
        nextAttack = 0;
        limitTime = 1.0f;
    }

    private void Update()
    {
        limitTime -= Time.deltaTime;
    }


    /// <summary>
    /// カードを使った時の処理をここで一度にやる
    /// </summary>
    public void UseCard()
    {
        if (charaSetAttackTurn.GetIsAttackTurn())
        {

            // ターゲットがいないなら、手札に戻す
            if (!attackTarget.GetTargetHP())
            {
                cardManager.UseCardReturn();
            }
            else if (limitTime < 0)
            {
                cardParameterData = cardManager.GetUseCard();//使用したカードのパラメーターを取得

                if (cardParameterData.cardType != 0 && attackTarget.GetTargetHP())
                {
                    currentCombo = playerCombo.ComboJudge(cardParameterData.cardType);

                    //コンボの判定
                    CardAbility cardAbility = cardAbilityTable.CardAbilityList[cardParameterData.cardRarity].CardAbilities[cardParameterData.cardAbility];//カードの効果を発動
                    cardAbility.Execute(this, cardManager);
                    stamina.UseStamina(cardDataBase.CardData[cardParameterData.cardType].stamina - nextStamina);//ｽﾀﾐﾅを消費        

                    if (attackTarget.GetTargetHP())
                        attackTarget.GetTargetHP().TakeDamage(CalculationPower());

                    comboCount.SetComboCount(currentCombo);

                    nextStamina = 0;

                    limitTime = 1.0f;
                }
                else
                {
                    comboCount.SetComboCount(0);
                }
            }
        }
        else
        {
            playerCombo.ResetCombo();
        }
    }

    /// <summary>
    /// 攻撃力の計算
    /// </summary>
    /// <returns></returns>
    private float CalculationPower()
    {
        float power = 0;
        float cardPower = cardDataBase.CardData[cardParameterData.cardType].damage;

        power = (cardPower)*comboPower[currentCombo];
        power += nextAttack;
        if(isNextMagicPower&&cardParameterData.cardType==(int)CardType.MAGIC)        
        {
            power += cardPower / 10;
        }

        if(prevMaxCombo)
        {
            power += cardPower / 10;
        }

        if(isMagicPower&&cardParameterData.cardType==(int)CardType.MAGIC)
        {
            power += 2;
        }
        

        nextAttack = 0;
        isNextMagicPower = false;

        return power;
    }

    
    


}
