using System;
using UnityEngine;


[Serializable]
public struct CardParameterData
{
    
    public float cardDamage;// カードの攻撃力
    public int cardAbility;// カードの能力
    public int cardRarity;// カードのレア度
    public int cardType;// カードの種類

    public CardParameterData(float damage,int ability, int rarity, int type)
    {
        cardDamage = damage;
        cardAbility = ability;
        cardRarity = rarity;
        cardType = type;
    }
}
