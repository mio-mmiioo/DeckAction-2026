using UnityEngine;
using TMPro;

public class CardEffectExplainer : MonoBehaviour
{
    CardParameterData cardParameterData;
    CardAbilityTable cardAbilityTable;
    TextMeshProUGUI explain;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //explain = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCardParameter(CardParameterData cardParameter)
    {
        //cardParameterData = cardParameter;
        //explain.text = cardAbilityTable.CardAbilityList[cardParameterData.cardRarity].CardAbilities[cardParameterData.cardAbility].explation;


    }
}
