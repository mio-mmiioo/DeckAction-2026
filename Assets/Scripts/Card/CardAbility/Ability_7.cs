using UnityEngine;

[CreateAssetMenu(fileName = "Ability_7", menuName = "Abilities/Ability_7")]
public class Ability_7 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        user.isNextMagicPower = true;
    }
}

