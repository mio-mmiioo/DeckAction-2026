using UnityEngine;

[CreateAssetMenu(fileName = "Ability_11", menuName = "Abilities/Ability_11")]
public class Ability_11 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        if(cardManager.isAllMagic)
        {
            user.isMagicPower=true;
        }
        else
        {

        }
    }
}

