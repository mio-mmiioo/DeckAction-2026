using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CardAbilityTable", menuName = "Scriptable Objects/CardAbilityTable")]
public class CardAbilityTable : ScriptableObject
{
    public List<CardAbility> CardAbilityList = new List<CardAbility>();
}
