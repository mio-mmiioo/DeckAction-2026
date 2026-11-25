using UnityEngine;

[CreateAssetMenu(fileName = "Ability_6", menuName = "Abilities/Ability_6")]
public class Ability_6 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        cardManager.AddCardTypeSet(2);
    }
}

