using UnityEngine;

[CreateAssetMenu(fileName = "Ability_2", menuName = "Abilities/Ability_2")]
public class Ability_2 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        user.nextStamina = -2;
    }
}

