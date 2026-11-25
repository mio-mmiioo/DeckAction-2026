using UnityEngine;
using TMPro;
using UnityEngine.UI;
/// <summary>
/// カードの説明をする部分のスクリプト
/// </summary>
public class CardEffectExplainer : MonoBehaviour
{

    private CardParameterData cardParameterData;
    [SerializeField] private CardAbilityTable cardAbilityTable;
    [SerializeField] private CardDataBase cardDataBase;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI explain;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI rarity;
    [SerializeField] private TextMeshProUGUI cardName;

    [SerializeField] private Image effectBar;
    [SerializeField] private Image cardNameBar;
    private Image background;
    public byte[] color = new byte[3];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        background = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCardParameter(CardParameterData cardParameter)
    {
        background.enabled = true;

        cardParameterData = cardParameter;
        explain.text = cardAbilityTable.CardAbilityList[cardParameterData.cardRarity].CardAbilities[cardParameterData.cardAbility].explation;
        damage.text = ("攻撃:") + cardParameterData.cardDamage;
        rarity.text = ("☆") + (cardParameterData.cardRarity + 1);
        cardName.text = cardDataBase.CardData[cardParameterData.cardType].cardName;

        color[0] = cardDataBase.CardData[cardParameterData.cardType].RGB[0];
        color[1] = cardDataBase.CardData[cardParameterData.cardType].RGB[1];
        color[2] = cardDataBase.CardData[cardParameterData.cardType].RGB[2];

        effectBar.enabled = true;
        cardNameBar.enabled = true;

        effectBar.color = new Color32(color[0], color[1], color[2], 255);
        cardNameBar.color = new Color32(color[0], color[1], color[2], 255);

        image.enabled = true;
        image.sprite = cardDataBase.CardData[cardParameterData.cardType].image;

    }

    public void ResetCardParameter()
    {
        background.enabled = false;
        explain.text = "";
        damage.text = "";
        rarity.text = "";
        cardName.text = "";

        effectBar.enabled = false;
        cardNameBar.enabled = false;
        image.enabled = false;
    }

}