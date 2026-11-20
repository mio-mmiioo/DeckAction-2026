using UnityEngine;

[CreateAssetMenu(fileName = "Ability_8", menuName = "Abilities/Ability_8")]
public class Ability_8 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        if(user.prevMaxCombo)
        {
            user.plusAttack = true;
        }
    }
}

