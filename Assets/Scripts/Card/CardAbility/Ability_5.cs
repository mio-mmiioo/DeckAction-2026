using UnityEngine;

[CreateAssetMenu(fileName = "Ability_5", menuName = "Abilities/Ability_5")]
public class Ability_5 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        cardManager.AddCardTypeSet(CardType.PHYSICAL);
    }
}

