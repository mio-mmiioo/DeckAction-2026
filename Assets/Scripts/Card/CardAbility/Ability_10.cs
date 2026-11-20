using UnityEngine;

[CreateAssetMenu(fileName = "Ability_10", menuName = "Abilities/Ability_10")]
public class Ability_10 : CardAbility
{
    public override void Execute(PlayerUseCard user, CardManager cardManager)
    {
        if (user.currentCombo == 4)
        {
            int stamina = user.stamina.GetMaxStamina();
            stamina = stamina / 5;
            user.stamina.AddStamina(stamina);
        }
    }
}

