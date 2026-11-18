using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardAbilityTable", menuName = "Scriptable Objects/CardAbilityTable")]
public class CardAbilityTable : ScriptableObject
{
    public List<CardAbility> CardAbilityList_1 = new List<CardAbility>();
    public List<CardAbility> CardAbilityList_2 = new List<CardAbility>();
    public List<CardAbility> CardAbilityList_3 = new List<CardAbility>();
    public List<CardAbility> CardAbilityList_4 = new List<CardAbility>();
}
