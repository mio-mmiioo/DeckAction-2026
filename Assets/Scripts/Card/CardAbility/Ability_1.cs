using UnityEngine;

[CreateAssetMenu(fileName= "Ability_1",menuName = "Abilities/Ability_1")]
public class Ability_1 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        user.nextAttack += 5;
    }
}
