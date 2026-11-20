using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AbilityTable", menuName = "Scriptable Objects/AbilityTable")]
public class CardAbilityTable : ScriptableObject
{
    
    public List<AbilityTable> CardAbilityList = new List<AbilityTable>();
}

[System.Serializable]
public class AbilityTable
{
    public List<CardAbility> CardAbilities = new List<CardAbility>();
}

